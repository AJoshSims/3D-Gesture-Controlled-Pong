using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public static Effects effects;

    private float lastTime01;

    private float lastTime02;

    private System.Random randomNumGenerator;

    private GameObject[] goalZoneSegmentsPlayerOne;

    private GameObject[] goalZoneSegmentsPlayerTwo;

    private int[] goalZoneSegmentIndicesAbleToConsume;

    private int[] goalZoneSegmentIndicesPoints;

    private const int numOfGoalZoneSegmentsPerPlayer = 4;

    internal void addToGoalZoneSegmentsPlayerOne(
        int index, GameObject goalZoneSegment)
    {
        goalZoneSegmentsPlayerOne[index] = goalZoneSegment;
    }

    internal void addToGoalZoneSegmentsPlayerTwo(
        int index, GameObject goalZoneSegment)
    {
        goalZoneSegmentsPlayerTwo[index] = goalZoneSegment;
    }

    private void Awake()
    {
        if (effects == null)
        {
            DontDestroyOnLoad(gameObject);
            effects = this;
        }

        else if (effects != this)
        {
            Destroy(gameObject);
        }

        goalZoneSegmentsPlayerOne = 
            new GameObject[numOfGoalZoneSegmentsPerPlayer];
        goalZoneSegmentsPlayerTwo = 
            new GameObject[numOfGoalZoneSegmentsPerPlayer];

        goalZoneSegmentIndicesAbleToConsume = 
            new int[numOfGoalZoneSegmentsPerPlayer * 2];
        goalZoneSegmentIndicesPoints = 
            new int[numOfGoalZoneSegmentsPerPlayer * 2];

        lastTime01 = 0;
        lastTime02 = 0;

        randomNumGenerator = new System.Random();
    }

	void Update ()
    {
		if ((Time.time - lastTime01) > 5)
        {
            // TODO Change to random number
            int randomGoalZoneSegmentIndex = randomNumGenerator.Next(4);
            GameObject affectedGoalZoneSegment = 
                goalZoneSegmentsPlayerTwo[0];

            GoalZoneSegmentBehavior goalZoneSegmentBehaviour = 
                affectedGoalZoneSegment
                .GetComponent<GoalZoneSegmentBehavior>();
            goalZoneSegmentBehaviour.setAbleToConsumeBall(false);
            goalZoneSegmentIndicesAbleToConsume

            // TODO reenable ability to consume ball
            lastTime01 = Time.deltaTime;
            //affectedGoalZoneSegment.
        }

        if ((Time.time - lastTime02) > 10)
        {

        }
	}
}
