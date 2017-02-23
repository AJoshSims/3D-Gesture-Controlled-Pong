using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneSegmentBehavior : MonoBehaviour
{
    private bool ableToConsumeBall;

    private int goalZoneSegmentIndex;

    private const int zPositionPlayerOne = -1;

    internal void setAbleToConsumeBall(bool ableToConsumeBall)
    {
        this.ableToConsumeBall = ableToConsumeBall;
    }

    internal bool isAbleToConsumeBall()
    {
        return ableToConsumeBall;
    }

	void Start ()
    {
        setAbleToConsumeBall(true);

        if (Mathf.Sign(transform.position.z) == zPositionPlayerOne)
        {
            if (Mathf.Sign(transform.position.x) == -1)
            {
                if (Mathf.Sign(transform.position.y) == 1)
                {
                    Effects.effects.addToGoalZoneSegmentsPlayerOne(
                        0, gameObject);
                }
                else
                {
                    Effects.effects.addToGoalZoneSegmentsPlayerOne(
                        1, gameObject);
                }
            }

            else
            {
                if (Mathf.Sign(transform.position.y) == -1)
                {
                    Effects.effects.addToGoalZoneSegmentsPlayerOne(
                        2, gameObject);
                }
                else
                {
                    Effects.effects.addToGoalZoneSegmentsPlayerOne(
                        3, gameObject);
                }
            }
        }

        else
        {
            if (Mathf.Sign(transform.position.x) == 1)
            {
                if (Mathf.Sign(transform.position.y) == 1)
                {
                    Effects.effects.addToGoalZoneSegmentsPlayerTwo(
                        0, gameObject);
                }
                else
                {
                    Effects.effects.addToGoalZoneSegmentsPlayerTwo(
                        1, gameObject);
                }
            }

            else
            {
                if (Mathf.Sign(transform.position.y) == -1)
                {
                    Effects.effects.addToGoalZoneSegmentsPlayerTwo(
                        2, gameObject);
                }
                else
                {
                    Effects.effects.addToGoalZoneSegmentsPlayerTwo(
                        3, gameObject);
                }
            }
        }
    }
}
