using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehaviorExtra : MonoBehaviour, BallBehavior
{
    public PaddleBehaviorAI paddleBehaviorAI;

    private bool active;

    public int ballExtraIndex;

    private bool toBePursued;

    private bool isAway;

    public BallBehaviorMain ballBehaviorMainRef;

    private Vector3 originalPosition;

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

    public bool Active
    {
        get
        {
            return active;
        }
    }

    internal void Activate()
    {
        active = true;

        transform.position = ballBehaviorMainRef.transform.position;
        GetComponent<Rigidbody>().velocity =
            new Vector3(0, 0, ballBehaviorMainRef.Speed / 2);
    }

    private void Awake()
    {
        toBePursued = false;
        isAway = false;
        originalPosition = transform.position;
    }

    private void Start()
    {
        EffectExtraBalls.effectExtraBalls.prepareBallExtra(
            this, ballExtraIndex);
    }

    public void FixedUpdate()
    {
        if (
            (active == true)
            && (transform.position.z > 0)
            && (toBePursued == false)
            && (isAway == false))
        {
            PaddleBehaviorAI.AddBallToQueue(gameObject);
            toBePursued = true;
        }

        else if (
            (active == true)
            && (transform.position.z <= 0)
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
                active = false;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                transform.position = originalPosition;

                EffectExtraBalls.effectExtraBalls.confirmCanSpawnBallsExtra();

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
