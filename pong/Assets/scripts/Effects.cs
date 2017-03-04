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

    private Queue<GameObject> goalZoneSegmentsAbleToConsumePlayerOne;

    private Queue<GameObject> goalZoneSegmentsAbleToConsumePlayerTwo;

    private Queue<GameObject> goalZoneSegmentsPointsPlayerOne;

    private Queue<GameObject> goalZoneSegmentsPointsPlayerTwo;

    private const int numOfGoalZoneSegmentsPerPlayer = 4;

    public Color wallSideColor;

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

        goalZoneSegmentsAbleToConsumePlayerOne =
            new Queue<GameObject>(numOfGoalZoneSegmentsPerPlayer);
        goalZoneSegmentsAbleToConsumePlayerTwo =
            new Queue<GameObject>(numOfGoalZoneSegmentsPerPlayer);

        goalZoneSegmentsPointsPlayerOne =
            new Queue<GameObject>(numOfGoalZoneSegmentsPerPlayer);
        goalZoneSegmentsPointsPlayerTwo =
            new Queue<GameObject>(numOfGoalZoneSegmentsPerPlayer);

        lastTime01 = 0;
        lastTime02 = 0;

        randomNumGenerator = new System.Random();
    }

	void Update ()
    {
        if (Time.time > 0 || Time.time > 25)
        {
            // TODO Change to random number
            int randomGoalZoneSegmentIndex = randomNumGenerator.Next(4);
            GameObject affectedGoalZoneSegment = 
                goalZoneSegmentsPlayerTwo[0];

            GoalZoneSegmentBehavior goalZoneSegmentBehaviour = 
                affectedGoalZoneSegment
                .GetComponent<GoalZoneSegmentBehavior>();
            goalZoneSegmentBehaviour.setAbleToConsumeBall(false);

            goalZoneSegmentsAbleToConsumePlayerTwo.Enqueue(
                affectedGoalZoneSegment);

            // TODO reenable ability to consume ball
            lastTime01 = Time.time;
            //affectedGoalZoneSegment.

            Material affectedMaterial =
                affectedGoalZoneSegment.GetComponent<MeshRenderer>().material;
            affectedMaterial.color = wallSideColor;
        }

        if (Time.time > 15 && Time.time < 25)
        {
            if (goalZoneSegmentsAbleToConsumePlayerTwo.Count > 0)
            {
                GameObject resetGoalZoneSegment = 
                    goalZoneSegmentsAbleToConsumePlayerTwo.Dequeue();

                GoalZoneSegmentBehavior goalZoneSegmentBehaviourReset =
                    resetGoalZoneSegment
                    .GetComponent<GoalZoneSegmentBehavior>();

                goalZoneSegmentBehaviourReset.setAbleToConsumeBall(true);

                lastTime02 = Time.time;

                Material resetMaterial = 
                    resetGoalZoneSegment.GetComponent<MeshRenderer>().material;
                resetMaterial.color = Color.black;
            }
        }
	}
}
