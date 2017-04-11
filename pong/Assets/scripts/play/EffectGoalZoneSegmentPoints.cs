using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EffectGoalZoneSegmentPoints : MonoBehaviour
{
    public static EffectGoalZoneSegmentPoints effectGoalZoneSegmentPoints;

    private Settings.GameplayEffectMode mode;

    private System.Random randomNumGenerator;

    private const int numOfGoalZoneSegmentsPerPlayer = 4;

    private GoalZoneSegmentBehavior[] goalZoneSegmentBehaviorsPlayerOne;

    private GoalZoneSegmentBehavior[] goalZoneSegmentBehaviorsPlayerTwo;

    private int timeUntilModifyGoalZoneSegmentPoints;

    internal Settings.GameplayEffectMode Mode
    {
        get
        {
            return mode;
        }

        set
        {
            mode = value;
        }
    }

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
    }

    private void Start()
    {
        if (
            (Settings.settings.getGameplayEffectMode(
            Settings.goalZoneSegmentExtraPoints)
            == Settings.GameplayEffectMode.Immediate)
            || (Settings.settings.getGameplayEffectMode(
            Settings.goalZoneSegmentExtraPoints)
            == Settings.GameplayEffectMode.ScoreDependent))
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }

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
