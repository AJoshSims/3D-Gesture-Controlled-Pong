using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalZoneConsumesBall : MonoBehaviour
{
    private float thisGoalZone;

    private const float goalZone01 = 10;

    private const float goalZone02 = -10;

    public Text paddle01ScoreDisplay;

    private int paddle01Score;

    public Text paddle02ScoreDisplay;

    private int paddle02Score;

    private string scorer;

    private int scorerScore;

    private const float beginningXPositionOfBall = 0;

    private const float fixedYPositionOfBall = 0.25F;

    private const float beginningZPositionOfBall = 0;

    private void Start()
    {
        thisGoalZone = transform.position.x;

        paddle01ScoreDisplay.text = "Player One: 0";
        paddle02ScoreDisplay.text = "Player Two: 0";
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;

        if (thisGoalZone == goalZone02)
        {
            paddle01Score++;

            paddle01ScoreDisplay.text = scorer + "Player One: " +
                paddle01Score;
        }
        else
        {
            paddle02Score++;

            paddle02ScoreDisplay.text = scorer + "Player Two: " + 
                paddle02Score;
        }

        ResetBall(ball);
    }

    private void ResetBall(GameObject ball)
    {
        ResetBallPosition(ball);

        StartCoroutine(WaitAndInitiateBallMovementRelativeToGoal(ball));
    }

    private void ResetBallPosition(GameObject ball)
    {
        ball.transform.position = new Vector3(
            beginningXPositionOfBall, 
            fixedYPositionOfBall, 
            beginningZPositionOfBall);

        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
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