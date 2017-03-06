using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacleBehavior : MonoBehaviour
{
    private int timeUntilDestroy;

    internal void setTimeUntilDestroy(int timeUntilDestroy)
    {
        this.timeUntilDestroy = timeUntilDestroy;
    }

    private void Update()
    {
        if (Time.time > timeUntilDestroy)
        {
            Destroy(gameObject);
        }
    }
}
