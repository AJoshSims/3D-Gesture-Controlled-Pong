using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    public int speed;

	private void Start()
    {
        StartCoroutine(WaitAndInitiateBallMovement());
    }

    private IEnumerator WaitAndInitiateBallMovement()
    {
        yield return new WaitForSecondsRealtime(2);

        InitiateBallMovement(speed);

    }

    internal void InitiateBallMovement(float zVelocityAsSpecifiedBySpeed)
    {
        const float xVelocityOfZero = 0;
        const float yVelocityOfZero = 0;
        GetComponent<Rigidbody>().AddForce(
            xVelocityOfZero, yVelocityOfZero, zVelocityAsSpecifiedBySpeed, 
            ForceMode.Impulse);
    }
}