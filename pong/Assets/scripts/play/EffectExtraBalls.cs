using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExtraBalls : MonoBehaviour
{
    private static EffectExtraBalls effectExtraBalls;

    private int timeUntilExtraBalls;

    private System.Random randomNumGenerator;

    private const int maxNumOfExtraBalls = 5;

    private int numOfExtraBalls;

    public PaddleBehaviorAI paddleBehaviorAI;

    public Transform arenaTransform;

    public Object extraBallPrefab;

    public GameObject ballMain;

    private void Awake()
    {
        if (effectExtraBalls == null)
        {
            effectExtraBalls = this;
        }
        else
        {
            Destroy(gameObject);
        }

        randomNumGenerator = new System.Random();

        // timeUntilExtraBalls = randomNumGenerator.Next(30, 61);
        timeUntilExtraBalls = 4;
    }

    private void Update()
    {
        if (Time.time > timeUntilExtraBalls)
        {
            GameObject extraBall = (GameObject)Instantiate(
                    extraBallPrefab,
                    new Vector3(3, 3, 0),
                    ballMain.transform.rotation,
                    arenaTransform);

            extraBall.GetComponent<BallBehaviorExtra>().PaddleBehaviorAI =
                 paddleBehaviorAI;

            //extraBall.GetComponent<Rigidbody>().velocity =
            //    ballMain.GetComponent<Rigidbody>().velocity.normalized;

            extraBall.GetComponent<Rigidbody>().velocity = 
                new Vector3(5, 9, 20);

            timeUntilExtraBalls = (int)Time.time + 1;
        }
    }
}
