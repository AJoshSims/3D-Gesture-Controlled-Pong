using UnityEngine;
using System.Collections;

public class PaddleBehaviour : MonoBehaviour
{
    public PaddleUser thisPaddleUser;

    public int paddleSpeed;

    void Start()
    {
        if (thisPaddleUser == PaddleUser.AI)
        {
            Rigidbody AIPaddle = GetComponent<Rigidbody>();

            AIPaddle.AddForce(0, 0, paddleSpeed * AIPaddle.mass, 
                ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float userInput = 0;

        switch (thisPaddleUser)
        {
            case PaddleUser.Player01:
                userInput = Input.GetAxis("Player01");
                break;
            case PaddleUser.Player02:
                userInput = Input.GetAxis("Player02");
                break;
        }

        transform.position += new Vector3(0, 0, userInput * paddleSpeed * 
            Time.deltaTime);
    }
}

public enum PaddleUser
{
    Player01, Player02, AI
}
