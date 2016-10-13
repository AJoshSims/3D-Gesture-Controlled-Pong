using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    public int speed;

    //public GameObject AIPaddle;

	private void Start ()
    {
        InitiateBallMovement(speed);
    }

    internal void InitiateBallMovement(float xVelocityAsSpecifiedBySpeed)
    {
        const float yVelocityOfZero = 0;
        const float zVelocityOfZero = 0;
        GetComponent<Rigidbody>().AddForce(
            xVelocityAsSpecifiedBySpeed, yVelocityOfZero, zVelocityOfZero, 
            ForceMode.Impulse);
    }
}