using UnityEngine;
using System.Collections;

public class PaddleBehaviour : MonoBehaviour
{
    public PaddleUser thisPaddleUser;

    private Vector3 positionOfAIPaddle;

    private float fixedXPositionOfAIPaddle;

    private float fixedYPositionOfAIPaddle;

    private float changingZPositionOfAIPaddle = 0;

    public int paddleSpeed;

    public GameObject ball;

    private Vector3 positionOfBall;

    void Start()
    {
        fixedXPositionOfAIPaddle = GetComponent<Transform>().position.x;
        fixedYPositionOfAIPaddle = GetComponent<Transform>().position.y;
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
        float updatedZPositionOfAIPaddle = Mathf.SmoothDamp(
            transform.position.z, 
            ball.transform.position.z, 
            ref changingZPositionOfAIPaddle, 0.5f);

        transform.position = new Vector3(
            fixedXPositionOfAIPaddle,
            fixedYPositionOfAIPaddle,
            updatedZPositionOfAIPaddle);

        // Code for undefeatable AI.
        //float zPositionOfBall = ball.GetComponent<Transform>().position.z;

        //GetComponent<Transform>().position = 
        //    new Vector3(fixedXPositionOfPaddle, fixedYPositionOfPaddle, 
        //        zPositionOfBall);
    }
}

public enum PaddleUser
{
    Player01, Player02, AI
}
