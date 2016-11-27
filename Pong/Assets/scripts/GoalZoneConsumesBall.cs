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

        player01ScoreDisplay.text = "Player One: " + player01Goals;
        player02ScoreDisplay.text = "Player Two: " + player02Goals;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball = collision.gameObject;

        bool goalScored = false;

        if (thisGoalZoneX == goalZone02X)
        {
            ++player01Goals;
            ++Statistics.statistics.pongPlayer01WinGoals;
            ++Statistics.statistics.pongPlayer02LossGoals;

            if (thisGoalZoneZ == goalZone02RightZ)
            {
                ++Statistics.statistics.pongPlayer01WinGoalsLeft;
                ++Statistics.statistics.pongPlayer02LossGoalsRight;
            }

            else if (thisGoalZoneZ == goalZone02MiddleZ)
            {
                ++Statistics.statistics.pongPlayer01WinGoalsMiddle;
                ++Statistics.statistics.pongPlayer02LossGoalsMiddle;
            }

            else if (thisGoalZoneZ == goalZone02LeftZ)
            {
                ++Statistics.statistics.pongPlayer01WinGoalsRight;
                ++Statistics.statistics.pongPlayer02LossGoalsLeft;
            }

            if ((player01Goals % 5) == 0)
            {
                ++Statistics.statistics.pongPlayer01Wins;
                ++Statistics.statistics.pongPlayer02Losses;
                goalScored = true;
            }

            // TODO restore
            //player01ScoreDisplay.text =
            //    "Player One: " + player01Goals;
        }

        else if (thisGoalZoneX == goalZone01X)
        {
            ++player02Goals;
            ++Statistics.statistics.pongPlayer02WinGoals;
            ++Statistics.statistics.pongPlayer01LossGoals;

            if (thisGoalZoneZ == goalZone01RightZ)
            {
                ++Statistics.statistics.pongPlayer02WinGoalsLeft;
                ++Statistics.statistics.pongPlayer01LossGoalsRight;
            }

            else if (thisGoalZoneZ == goalZone01MiddleZ)
            {
                ++Statistics.statistics.pongPlayer02WinGoalsMiddle;
                ++Statistics.statistics.pongPlayer01LossGoalsMiddle;
            }

            else if (thisGoalZoneZ == goalZone01LeftZ)
            {
                ++Statistics.statistics.pongPlayer02WinGoalsRight;
                ++Statistics.statistics.pongPlayer01LossGoalsLeft;
            }

            if ((player02Goals % 5) == 0)
            {
                ++Statistics.statistics.pongPlayer02Wins;
                ++Statistics.statistics.pongPlayer01Losses;
                goalScored = true;
            }

            // TODO restore
            //player02ScoreDisplay.text =
            //    "Player Two: " + player02Goals;
        }

        ResetBall(ball);

        // TODO remove
        player01ScoreDisplay.text =
            "Player One: " + player01Goals;
        player02ScoreDisplay.text =
            "Player Two: " + player02Goals;

        Statistics.statistics.Save();
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