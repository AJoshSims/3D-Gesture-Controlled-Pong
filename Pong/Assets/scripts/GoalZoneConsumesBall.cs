using UnityEngine;
using System.Collections;

public class GoalZoneConsumesBall : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;

        ball.transform.position = new Vector3(0, (float)0.25, 0);

        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        ball.GetComponent<BallBehaviour>().Invoke("InitiateBallMovement", 1);
    }
}
