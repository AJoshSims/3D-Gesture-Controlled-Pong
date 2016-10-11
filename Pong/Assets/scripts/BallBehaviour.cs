using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    public int speed;

	void Start ()
    {
        InitiateBallMovement(speed);
    }

    internal void InitiateBallMovement(float xVelocity)
    {
        GetComponent<Rigidbody>().AddForce(xVelocity, 0, 0, ForceMode.Impulse);
    }
}
