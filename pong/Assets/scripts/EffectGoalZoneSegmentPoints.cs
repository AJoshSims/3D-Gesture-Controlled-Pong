using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EffectGoalZoneSegmentPoints : MonoBehaviour
{
    public static EffectGoalZoneSegmentPoints effectGoalZoneSegmentPoints;

    private System.Random randomNumGenerator;

    private const int numOfGoalZoneSegmentsPerPlayer = 4;

    private GoalZoneSegmentBehavior[] goalZoneSegmentBehaviorsPlayerOne;

    private GoalZoneSegmentBehavior[] goalZoneSegmentBehaviorsPlayerTwo;

    private int timeUntilModifyGoalZoneSegmentPoints;

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
        if (effectGoalZoneSegmentPoints == null)
        {
            DontDestroyOnLoad(gameObject);
            effectGoalZoneSegmentPoints = this;
        }

        else if (effectGoalZoneSegmentPoints != this)
        {
            Destroy(gameObject);
        }

        randomNumGenerator = new System.Random();

        goalZoneSegmentBehaviorsPlayerOne =
            new GoalZoneSegmentBehavior[numOfGoalZoneSegmentsPerPlayer];
        goalZoneSegmentBehaviorsPlayerTwo =
            new GoalZoneSegmentBehavior[numOfGoalZoneSegmentsPerPlayer];

        timeUntilModifyGoalZoneSegmentPoints =
            (int)Time.time + randomNumGenerator.Next(20, 31);
    }

    void Update()
    {
        if (Time.time > timeUntilModifyGoalZoneSegmentPoints)
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

            affectedGoalZoneSegmentBehavior.setPointsModified(true);

            timeUntilModifyGoalZoneSegmentPoints =
                (int) Time.time + randomNumGenerator.Next(20, 31);
        }
    }
}
