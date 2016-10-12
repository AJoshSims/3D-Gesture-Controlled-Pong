using UnityEngine;
using System.Collections;

public class GoalZoneConsumesBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;

        ResetBall(ball);
    }

    private void ResetBall(GameObject ball)
    {
        ResetBallPosition(ball);

        StartCoroutine(WaitAndInitiateBallMovementRelativeToGoal(ball));
    }

    private void ResetBallPosition(GameObject ball)
    {
        ball.transform.position = new Vector3(0, (float)0.25, 0);
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private IEnumerator WaitAndInitiateBallMovementRelativeToGoal(
        GameObject ball)
    {
        yield return new WaitForSecondsRealtime(1);

        InitiateBallMovementRelativeToGoal(ball);

    }

    private void InitiateBallMovementRelativeToGoal(GameObject ball)
    {
        float xVelocity = ball.GetComponent<BallBehaviour>().speed *
            Mathf.Sign(transform.position.x);
        ball.GetComponent<BallBehaviour>().InitiateBallMovement(xVelocity);
    }
}
