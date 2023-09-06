using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField]private PlayerInput playerInput;
    private InputAction move;
    private InputAction restart;
    private InputAction quit;

    private bool isPaddleMoving;
    [SerializeField]private GameObject paddle;
    [SerializeField]private float paddleSpeed;
    [SerializeField]private float moveDirection;
    [SerializeField]private GameObject brick;

    [SerializeField]private TMP_Text scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        DefinePlayerInput();

        isPaddleMoving = false;
        CreateBricks();

    }

    public void UpdateScore()
    {
        score += 100;
        scoreText.text = "Score: " + score.ToString();
    }

    private void CreateBricks()
    {
        Vector2 brickPos = new Vector2(-9, 4.5f);

        for (int j = 0; j < 4; ++j)
        {
            brickPos.x = -9;
            brickPos.y -= 1;
            for (int i = 0; i < 10; ++i)
            {
                brickPos.x += 1.64f;
                Instantiate(brick, brickPos, Quaternion.identity);
            }
        }
    }

    void DefinePlayerInput()
    {
        playerInput.currentActionMap.Enable();

        move = playerInput.currentActionMap.FindAction("MovePaddle");
        restart = playerInput.currentActionMap.FindAction("RestartGame");
        quit = playerInput.currentActionMap.FindAction("QuitGame");

        move.started += Move_started;
        move.canceled += Move_canceled;
        quit.started += Quit_started;
        restart.started += Restart_started;
    }

    private void Quit_started(InputAction.CallbackContext obj)
    {

    }
    private void Move_started(InputAction.CallbackContext obj)
    {
        isPaddleMoving = true;
    }
    private void Move_canceled(InputAction.CallbackContext obj)
    {
        isPaddleMoving = false;
    }
    private void Restart_started(InputAction.CallbackContext obj)
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isPaddleMoving)
        {
            // move the paddle
            paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(paddleSpeed * moveDirection, 0);
        }
        else
        {
            // stop paddle
            paddle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        if(isPaddleMoving)
        {
            moveDirection = move.ReadValue<float>();
        }
    }
}
