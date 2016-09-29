using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    public int speed;

	void Start ()
    {
        InitiateBallMovement();
    }

    void InitiateBallMovement()
    {
        GetComponent<Rigidbody>().AddForce(speed, 0, 0, ForceMode.Impulse);
    }
}
