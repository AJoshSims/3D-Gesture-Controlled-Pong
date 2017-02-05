using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneSegmentBehaviour : MonoBehaviour
{
    private bool ableToConsumeBall;

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
	}
}
