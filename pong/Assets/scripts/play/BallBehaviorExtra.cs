using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehaviorExtra : MonoBehaviour, BallBehavior
{
    private PaddleBehaviorAI paddleBehaviorAI;

    private bool toBePursued;

    private bool isAway;

    private BallBehaviorMain ballBehaviorMainRef;

    public BallBehaviorMain BallBehaviorMainRef
    {
        set
        {
            ballBehaviorMainRef = value;
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

        if ((GetComponent<Rigidbody>().velocity.magnitude
            < ballBehaviorMainRef.Speed)
            || (GetComponent<Rigidbody>().velocity.magnitude
            > ballBehaviorMainRef.Speed))
        {
            GetComponent<Rigidbody>().velocity = 
                GetComponent<Rigidbody>().velocity.normalized
                * (ballBehaviorMainRef.speed / 2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.collider.gameObject;

        GoalZoneSegmentBehavior goalZoneSegmentBehavior =
            collidedWith.GetComponent<GoalZoneSegmentBehavior>();

        if (goalZoneSegmentBehavior != null)
        {
            if (goalZoneSegmentBehavior.isAbleToConsumeBall() == true)
            {
                EffectExtraBalls.effectExtraBalls.decrementNumOfExtraBalls();

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

                Destroy(gameObject);
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
