using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Paddle paddle;
    public float xPush = 2f;
    public float yPush = 15f;
    Vector2 paddleToBallVector;
    bool hasStarted = false;


    // Start is called before the first frame update
    void Start()
    {

        paddleToBallVector = transform.position - paddle.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }


    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }
}
