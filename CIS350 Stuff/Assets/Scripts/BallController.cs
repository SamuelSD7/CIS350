using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject paddle;
    private bool isBallInPlay;

    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        isBallInPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isBallInPlay)
        {
            gameObject.transform.position = paddle.transform.position + new Vector3(0, 0.5f);
        }
    }

    public void LaunchBall()
    {
        if(!isBallInPlay)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, 10);
            isBallInPlay = true;
        }
    }
}
