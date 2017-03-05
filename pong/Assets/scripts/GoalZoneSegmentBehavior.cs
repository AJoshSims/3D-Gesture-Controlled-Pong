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

    private int timeUntilPointsNormalized;

    private System.Random randomNumGenerator;

    internal void setAbleToConsumeBall(bool ableToConsumeBall)
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
                (int) Time.time + randomNumGenerator.Next(10, 21);
        }
    }

    internal bool isAbleToConsumeBall()
    {
        return ableToConsumeBall;
    }

    private void Awake()
    {
        randomNumGenerator = new System.Random();
    }

	private void Start ()
    {
        ableToConsumeBall = true;

        if (Mathf.Sign(transform.position.z) == zPositionPlayerOne)
        {
            if (Mathf.Sign(transform.position.x) == -1)
            {
                if (Mathf.Sign(transform.position.y) == 1)
                {
                    EffectGoalZoneSegmentDisable.effects
                        .addToGoalZoneSegmentsPlayerOne(0, this);
                }
                else
                {
                    EffectGoalZoneSegmentDisable.effects.
                        addToGoalZoneSegmentsPlayerOne(1, this);
                }
            }

            else
            {
                if (Mathf.Sign(transform.position.y) == -1)
                {
                    EffectGoalZoneSegmentDisable.effects.
                        addToGoalZoneSegmentsPlayerOne(2, this);
                }
                else
                {
                    EffectGoalZoneSegmentDisable.effects.
                        addToGoalZoneSegmentsPlayerOne(3, this);
                }
            }
        }

        else
        {
            if (Mathf.Sign(transform.position.x) == 1)
            {
                if (Mathf.Sign(transform.position.y) == 1)
                {
                    EffectGoalZoneSegmentDisable.effects.
                        addToGoalZoneSegmentsPlayerTwo(0, this);
                }
                else
                {
                    EffectGoalZoneSegmentDisable.effects.
                        addToGoalZoneSegmentsPlayerTwo(1, this);
                }
            }

            else
            {
                if (Mathf.Sign(transform.position.y) == -1)
                {
                    EffectGoalZoneSegmentDisable.effects.
                        addToGoalZoneSegmentsPlayerTwo(2, this);
                }
                else
                {
                    EffectGoalZoneSegmentDisable.effects.
                        addToGoalZoneSegmentsPlayerTwo(3, this);
                }
            }
        }
    }

    private void Update()
    {
        if ((ableToConsumeBall == false) && (Time.time > timeUntilEnabled))
        {
            setAbleToConsumeBall(true);
        }
    }
}
