using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviorExtra : MonoBehaviour, BallBehavior
{
    private PaddleBehaviorAI paddleBehaviorAI;

    private bool toBePursued;

    private bool isAway;

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.collider.gameObject;

        GoalZoneSegmentBehavior goalZoneSegmentBehaviour =
            collidedWith.GetComponent<GoalZoneSegmentBehavior>();

        if (goalZoneSegmentBehaviour != null)
        {
            if (goalZoneSegmentBehaviour.isAbleToConsumeBall() == true)
            {
                EffectExtraBalls.effectExtraBalls.decrementNumOfExtraBalls();
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
