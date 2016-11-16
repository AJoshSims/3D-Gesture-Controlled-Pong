using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalZoneConsumesBall : MonoBehaviour
{
    private float thisGoalZoneX;

    private float thisGoalZoneZ;

    private const float goalZone01X = 10;

    private const float goalZone01LeftZ = -2.375F;

    private const float goalZone01RightZ = 2.375F;

    private const float goalZone02X = -10;

    private const float goalZone02LeftZ = 2.375F;

    private const float goalZone02RightZ = 2.375F;

    public Text paddle01ScoreDisplay;

    private static int paddle01Score;

    public Text paddle02ScoreDisplay;

    private static int paddle02Score;

    private const float beginningXPositionOfBall = 0;

    private const float fixedYPositionOfBall = 0.25F;

    private const float beginningZPositionOfBall = 0;

    private void Start()
    {
        thisGoalZoneX = transform.position.x;
        thisGoalZoneZ = transform.position.z;

        paddle01ScoreDisplay.text = "Player One: 0";
        paddle02ScoreDisplay.text = "Player Two: 0";
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;

        if (thisGoalZoneX == goalZone02X)
        {
            ++paddle01Score;

            paddle01ScoreDisplay.text = "Player One: " +
                paddle01Score;

            //if ((paddle01Score % 5) == 0)
            //{
            //    ++Statistics.statistics.player01Wins;
            //    Statistics.statistics.Save();
            //}
        }
        else if (thisGoalZoneX == goalZone01X)
        {
            ++paddle02Score;

            paddle02ScoreDisplay.text = "Player Two: " + 
                paddle02Score;

            //if ((paddle02Score % 5) == 0)
            //{
            //    ++Statistics.statistics.player02Wins;
            //    Statistics.statistics.Save();
            //}
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