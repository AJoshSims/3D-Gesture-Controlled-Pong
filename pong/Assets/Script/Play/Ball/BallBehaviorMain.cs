using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class BallBehaviorMain : MonoBehaviour, BallBehavior
{
    private const float beginningXPositionOfBall = 0;
    private const float beginningYPositionOfBall = 0;
    private const float beginningZPositionOfBall = 0;

    public int speed;

    private const float zPositionGoalZonePlayer01 = -39;
    private const float zPositionGoalZonePlayer02 = 39;

    public PaddleBehaviorAI paddleBehaviorAI;

    private bool toBePursued;

    private bool isAway;

    public int Speed
    {
        get
        {
            return speed;
        }
    }

    public PaddleBehaviorAI PaddleBehaviorAI
    {
        get
        {
            return paddleBehaviorAI;
        }
        set
        {
            paddleBehaviorAI = value;
        }
    }

    public bool ToBePursued
    {
        get
        {
            return toBePursued;
        }

        set
        {
            toBePursued = value;
        }
    }

    public bool IsAway
    {
        get
        {
            return isAway;
        }

        set
        {
            isAway = value;
        }
    }

    private void Awake()
    {
        toBePursued = false;
        isAway = false;
    }

    private void Start()
    {
        StartCoroutine(WaitAndInitiateBallMovement(zPositionGoalZonePlayer01));
    }

    private void ResetBall(float zPositionGoalZone)
    {
        toBePursued = false;
        isAway = false;

        transform.position = new Vector3(
            beginningXPositionOfBall,
            beginningYPositionOfBall,
            beginningZPositionOfBall);

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        StartCoroutine(WaitAndInitiateBallMovement(zPositionGoalZone));
    }

    private IEnumerator WaitAndInitiateBallMovement(float zPositionGoalZone)
    {
        yield return new WaitForSecondsRealtime(2);

        InitiateBallMovement(zPositionGoalZone);
    }

    internal void InitiateBallMovement(float zPositionGoalZone)
    {
        const float xVelocityOfZero = 0;
        const float yVelocityOfZero = 0;
        GetComponent<Rigidbody>().velocity = new Vector3(
            xVelocityOfZero,
            yVelocityOfZero,
            speed * Mathf.Sign(zPositionGoalZone));
    }

    public void FixedUpdate()
    {
        if (
            (transform.position.z > 0)
            && (toBePursued == false)
            && (isAway == false))
        {
            PaddleBehaviorAI.AddBallToQueue(gameObject);
            toBePursued = true;
        }

        else if ((transform.position.z <= 0)
            && (isAway == true))
        {
            isAway = false;
        }

        if ((GetComponent<Rigidbody>().velocity.magnitude < speed)
            || (GetComponent<Rigidbody>().velocity.magnitude > speed))
        {
            GetComponent<Rigidbody>().velocity =
                GetComponent<Rigidbody>().velocity.normalized * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.collider.gameObject;

        GoalZoneSegmentBehavior goalZoneSegmentBehavior =
            collidedWith.GetComponent<GoalZoneSegmentBehavior>();

        if (goalZoneSegmentBehavior != null)
        {
            if (goalZoneSegmentBehavior.isAbleToConsumeBall())
            {
                ResetBall(-collidedWith.transform.position.z);

                if (goalZoneSegmentBehavior.player01Owner == true)
                {
                    ScoreKeeperBehavior.scoreKeeperBehavior.incrementScore(
                        false, goalZoneSegmentBehavior.Points);
                }
                else
                {
                    ScoreKeeperBehavior.scoreKeeperBehavior.incrementScore(
                        true, goalZoneSegmentBehavior.Points);
                }
            }

            else
            {
                toBePursued = false;
                isAway = true;
            }
        }      

        // Else if it was an additive effect object...
    }
}