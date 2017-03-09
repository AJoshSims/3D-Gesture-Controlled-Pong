using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRandomObstacles : MonoBehaviour
{
    private EffectRandomObstacles effectRandomObstacles;

    private int timeUntilRandomObstacle;

    private System.Random randomNumGenerator;

    public GameObject arena;

    public Object randomObstaclePrefab;

    public GameObject ball;

    private void Awake()
    {
        if (effectRandomObstacles == null)
        {
            effectRandomObstacles = this;
        }
        else
        {
            Destroy(gameObject);
        }

        randomNumGenerator = new System.Random();

        timeUntilRandomObstacle = 
            (int) Time.time + randomNumGenerator.Next(5, 10);
    }

    private void Update()
    {
        if (Time.time > timeUntilRandomObstacle)
        {
            GameObject randomObstacle = (GameObject) Instantiate(
                randomObstaclePrefab,
                new Vector3(
                randomNumGenerator.Next(-9, 10),
                randomNumGenerator.Next(-5, 6),
                0),
                Quaternion.LookRotation(ball.transform.position),
                arena.transform);

            randomObstacle.transform.localScale =
                new Vector3(
                randomNumGenerator.Next(1, 6),
                randomNumGenerator.Next(1, 6),
                randomNumGenerator.Next(1, 6));

            RandomObstacleBehavior randomObstacleBehavior =
                randomObstacle.GetComponent<RandomObstacleBehavior>();

            randomObstacleBehavior.setTimeUntilDestroy(
                (int) Time.time + 20);

            timeUntilRandomObstacle =
                (int)Time.time + randomNumGenerator.Next(5, 10);
        }
    }
}
