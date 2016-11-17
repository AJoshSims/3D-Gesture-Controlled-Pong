using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalZoneConsumesBall : MonoBehaviour
{
    private float thisGoalZoneX;

    private float thisGoalZoneZ;

    private const float goalZone01X = 10;

    private const float goalZone01LeftZ = -(9 / 3);

    private const float goalZone01MiddleZ = 0;

    private const float goalZone01RightZ = (9 / 3);

    private const float goalZone02X = -10;

    private const float goalZone02LeftZ = (9 / 3);

    private const float goalZone02MiddleZ = 0;

    private const float goalZone02RightZ = -(9 / 3);

    public Text player01ScoreDisplay;

    private static int player01Goals;

    public Text player02ScoreDisplay;

    private static int player02Goals;

    private const float beginningXPositionOfBall = 0;

    private const float fixedYPositionOfBall = 0.25F;

    private const float beginningZPositionOfBall = 0;

    private void Start()
    {
        thisGoalZoneX = transform.position.x;
        thisGoalZoneZ = transform.position.z;

        player01ScoreDisplay.text = "Player One: 0 :: wins " + Statistics.statistics.player01Wins;
        player02ScoreDisplay.text = "Player Two: 0 :: wins " + Statistics.statistics.player02Wins;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;
        bool goalScored = false;

        if (thisGoalZoneX == goalZone02X)
        {
            ++player01Goals;
            ++Statistics.statistics.player01Goals;

            // TODO goal zone segment goal

            player01ScoreDisplay.text = "Player One: " +
                player01Goals + " :: wins " + Statistics.statistics.player01Wins;

            if ((player01Goals % 5) == 0)
            {
                ++Statistics.statistics.player01Wins;
                ++Statistics.statistics.player02Losses;
                goalScored = true;
            }
        }
        else if (thisGoalZoneX == goalZone01X)
        {
            ++player02Goals;
            ++Statistics.statistics.player02Goals;

            if ((player02Goals % 5) == 0)
            {
                ++Statistics.statistics.player02Wins;
                ++Statistics.statistics.player01Losses;
                goalScored = true;
            }

            player02ScoreDisplay.text = "Player Two: " +
                player02Goals + " :: wins " + Statistics.statistics.player02Wins;
        }

        if (goalScored == true)
        {
        Statistics.statistics.Save();
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