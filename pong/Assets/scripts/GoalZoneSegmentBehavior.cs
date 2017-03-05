using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneSegmentBehavior : MonoBehaviour
{
    public Color wallSideColor;

    private int goalZoneSegmentIndex;

    private const int zPositionPlayerOne = -1;

    private bool ableToConsumeBall;

    private int timeUntilEnabled;

    private int points;

    private const int pointsNormal = 1;

    private bool pointsModified;

    private const int pointsModification = 3;

    private int timeUntilPointsNormalized;

    private System.Random randomNumGenerator;

    internal void setAbleToConsumeBall(bool ableToConsumeBall)
    {
        if (pointsModified == false)
        {
            this.ableToConsumeBall = ableToConsumeBall;

            if (ableToConsumeBall == true)
            {
                GetComponent<MeshRenderer>().material.color = Color.black;
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = wallSideColor;
                timeUntilEnabled = 
                    (int) Time.time + randomNumGenerator.Next(5, 21);
            }
        }
    }

    internal bool isAbleToConsumeBall()
    {
        return ableToConsumeBall;
    }

    internal int getPoints()
    {
        return points;
    }

    internal void setPointsModified(bool pointsModified)
    {
        if (ableToConsumeBall == true)
        {
            this.pointsModified = pointsModified;

            if (pointsModified == true)
            {
                points = pointsModification;
                GetComponent<BlinkColor>().setBlinkActive(true);
                timeUntilPointsNormalized = (int) Time.time + 10;
            }
            else
            {
                points = pointsNormal;
                GetComponent<BlinkColor>().setBlinkActive(false);
            }
        }
    }

    private void Awake()
    {
        ableToConsumeBall = true;

        pointsModified = false;

        randomNumGenerator = new System.Random();
    }

	private void Start ()
    {
        if (Mathf.Sign(transform.position.z) == zPositionPlayerOne)
        {
            if (Mathf.Sign(transform.position.x) == -1)
            {
                if (Mathf.Sign(transform.position.y) == 1)
                {
                    EffectGoalZoneSegmentDisable.effectGoalZoneSegmentDisable
                        .addToGoalZoneSegmentsPlayerOne(0, this);

                    EffectGoalZoneSegmentPoints.effectGoalZoneSegmentPoints
                        .addToGoalZoneSegmentsPlayerOne(0, this);
                }
                else
                {
                    EffectGoalZoneSegmentDisable.effectGoalZoneSegmentDisable.
                        addToGoalZoneSegmentsPlayerOne(1, this);

                    EffectGoalZoneSegmentPoints.effectGoalZoneSegmentPoints
                        .addToGoalZoneSegmentsPlayerOne(1, this);
                }
            }

            else
            {
                if (Mathf.Sign(transform.position.y) == -1)
                {
                    EffectGoalZoneSegmentDisable.effectGoalZoneSegmentDisable.
                        addToGoalZoneSegmentsPlayerOne(2, this);

                    EffectGoalZoneSegmentPoints.effectGoalZoneSegmentPoints
                        .addToGoalZoneSegmentsPlayerOne(2, this);
                }
                else
                {
                    EffectGoalZoneSegmentDisable.effectGoalZoneSegmentDisable.
                        addToGoalZoneSegmentsPlayerOne(3, this);

                    EffectGoalZoneSegmentPoints.effectGoalZoneSegmentPoints
                        .addToGoalZoneSegmentsPlayerOne(3, this);
                }
            }
        }

        else
        {
            if (Mathf.Sign(transform.position.x) == 1)
            {
                if (Mathf.Sign(transform.position.y) == 1)
                {
                    EffectGoalZoneSegmentDisable.effectGoalZoneSegmentDisable.
                        addToGoalZoneSegmentsPlayerTwo(0, this);

                    EffectGoalZoneSegmentPoints.effectGoalZoneSegmentPoints
                        .addToGoalZoneSegmentsPlayerTwo(0, this);
                }
                else
                {
                    EffectGoalZoneSegmentDisable.effectGoalZoneSegmentDisable.
                        addToGoalZoneSegmentsPlayerTwo(1, this);

                    EffectGoalZoneSegmentPoints.effectGoalZoneSegmentPoints
                        .addToGoalZoneSegmentsPlayerTwo(1, this);
                }
            }

            else
            {
                if (Mathf.Sign(transform.position.y) == -1)
                {
                    EffectGoalZoneSegmentDisable.effectGoalZoneSegmentDisable.
                        addToGoalZoneSegmentsPlayerTwo(2, this);

                    EffectGoalZoneSegmentPoints.effectGoalZoneSegmentPoints
                        .addToGoalZoneSegmentsPlayerTwo(2, this);
                }
                else
                {
                    EffectGoalZoneSegmentDisable.effectGoalZoneSegmentDisable.
                        addToGoalZoneSegmentsPlayerTwo(3, this);

                    EffectGoalZoneSegmentPoints.effectGoalZoneSegmentPoints
                        .addToGoalZoneSegmentsPlayerTwo(3, this);
                }
            }
        }
    }

    private void Update()
    {
        if ((ableToConsumeBall == false) 
            && (Time.time > timeUntilEnabled))
        {
            setAbleToConsumeBall(true);
        }

        else if ((pointsModified == true) 
            && (Time.time > timeUntilPointsNormalized))
        {
            setPointsModified(false);
        }
    }
}
