using UnityEngine;
using System.Collections;

public class PaddleBehaviour : MonoBehaviour
{
    public PaddleUser thisPaddleUser;

    private float xPositionOfPaddle;

    private float yPositionOfPaddle;

    public int paddleSpeed;

    public GameObject ball;

    void Start()
    {
        xPositionOfPaddle = GetComponent<Transform>().position.x;
        yPositionOfPaddle = GetComponent<Transform>().position.y;
        //    if (thisPaddleUser == PaddleUser.AI)
        //    {
        //        Rigidbody AIPaddle = GetComponent<Rigidbody>();

        //        AIPaddle.AddForce(0, 0, paddleSpeed * AIPaddle.mass, 
        //            ForceMode.Impulse);
        //    }
    }

private void FixedUpdate()
    {
        float userInput = 0;

        switch (thisPaddleUser)
        {
            case PaddleUser.Player01:
                userInput = Input.GetAxis("Player01");
                movePlayerPaddle(userInput);
                break;
            case PaddleUser.Player02:
                userInput = Input.GetAxis("Player02");
                movePlayerPaddle(userInput);
                break;
            case PaddleUser.AI:
                moveAIPaddle();
                break;
        }
    }

    private void movePlayerPaddle(float userInput)
    {
        transform.position += new Vector3(0, 0, userInput * paddleSpeed *
            Time.deltaTime);
    }

    private void moveAIPaddle()
    {
        float zPositionOfBall = ball.GetComponent<Transform>().position.z;

        GetComponent<Transform>().position = 
            new Vector3(xPositionOfPaddle, yPositionOfPaddle, zPositionOfBall);
    }
}

public enum PaddleUser
{
    Player01, Player02, AI
}
