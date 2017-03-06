using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EffectGoalZoneSegmentDisable : MonoBehaviour
{
    public static EffectGoalZoneSegmentDisable effectGoalZoneSegmentDisable;

    private System.Random randomNumGenerator;

    private const int numOfGoalZoneSegmentsPerPlayer = 4;

    private GoalZoneSegmentBehavior[] goalZoneSegmentBehaviorsPlayerOne;

    private GoalZoneSegmentBehavior[] goalZoneSegmentBehaviorsPlayerTwo;

    private int timeUntilDisableGoalZoneSegment;

    internal void addToGoalZoneSegmentsPlayerOne(
        int index, GoalZoneSegmentBehavior goalZoneSegmentBehavior)
    {
        goalZoneSegmentBehaviorsPlayerOne[index] = goalZoneSegmentBehavior;
    }

    internal void addToGoalZoneSegmentsPlayerTwo(
        int index, GoalZoneSegmentBehavior goalZoneSegmentBehavior)
    {
        goalZoneSegmentBehaviorsPlayerTwo[index] = goalZoneSegmentBehavior;
    }

    private void Awake()
    {
        if (effectGoalZoneSegmentDisable == null)
        {
            effectGoalZoneSegmentDisable = this;
        }

        else if (effectGoalZoneSegmentDisable != this)
        {
            Destroy(gameObject);
        }

        randomNumGenerator = new System.Random();

        goalZoneSegmentBehaviorsPlayerOne = 
            new GoalZoneSegmentBehavior[numOfGoalZoneSegmentsPerPlayer];
        goalZoneSegmentBehaviorsPlayerTwo = 
            new GoalZoneSegmentBehavior[numOfGoalZoneSegmentsPerPlayer];

        timeUntilDisableGoalZoneSegment =
            (int)Time.time + randomNumGenerator.Next(5, 11);
    }
    
    void Update ()
    {
        if (Time.time > timeUntilDisableGoalZoneSegment)
        {
            GoalZoneSegmentBehavior[] goalZoneSegmentsToSelectFrom = null;

            if (randomNumGenerator.NextDouble() < 0.5)
            {
                goalZoneSegmentsToSelectFrom = 
                    goalZoneSegmentBehaviorsPlayerTwo;
            }
            else
            {
                goalZoneSegmentsToSelectFrom =
                    goalZoneSegmentBehaviorsPlayerOne;
            }

            GoalZoneSegmentBehavior affectedGoalZoneSegmentBehavior =
                goalZoneSegmentsToSelectFrom[randomNumGenerator.Next(
                    numOfGoalZoneSegmentsPerPlayer)];

            affectedGoalZoneSegmentBehavior.setAbleToConsumeBall(false);

            timeUntilDisableGoalZoneSegment =
                (int)Time.time + randomNumGenerator.Next(5, 11);
        }
	}
}
