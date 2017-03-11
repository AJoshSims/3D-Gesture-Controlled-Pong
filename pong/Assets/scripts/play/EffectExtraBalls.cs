using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExtraBalls : MonoBehaviour
{
    public static EffectExtraBalls effectExtraBalls;

    private int timeUntilExtraBalls;

    private System.Random randomNumGenerator;

    private const int maxNumOfExtraBalls = 5;

    private int numOfExtraBalls;

    public PaddleBehaviorAI paddleBehaviorAI;

    public Transform arenaTransform;

    public Object extraBallPrefab;

    public GameObject ballMain;

    private bool ballMainBlinking;

    public void decrementNumOfExtraBalls()
    {
        --numOfExtraBalls;
    }

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

        numOfExtraBalls = 0;

        randomNumGenerator = new System.Random();

        // timeUntilExtraBalls = randomNumGenerator.Next(30, 61);
        timeUntilExtraBalls = 5;

        ballMainBlinking = false;
    }

    private void Update()
    {
        if (
            (Time.time > timeUntilExtraBalls) 
            && (ballMainBlinking == false) 
            && (numOfExtraBalls != maxNumOfExtraBalls))
        {
            ballMainBlinking = true;

            StartCoroutine(waitAndSpawnExtraBalls());
        }
    }

    private IEnumerator waitAndSpawnExtraBalls()
    {
        BlinkColor ballMainBlink = ballMain.GetComponent<BlinkColor>();
        ballMainBlink.setBlinkActive(true);

        yield return new WaitForSecondsRealtime(2);

        ballMainBlink.setBlinkActive(false);

        ballMainBlinking = false;

        spawnExtraBalls();
    }

    private void spawnExtraBalls()
    {
        GameObject extraBall;

        int numOfBallsToSpawn = randomNumGenerator.Next(
            1, maxNumOfExtraBalls - numOfExtraBalls);

        numOfExtraBalls += numOfBallsToSpawn;

        for (
            ;
            numOfBallsToSpawn > 0;
            --numOfBallsToSpawn)
        {
            extraBall = (GameObject)Instantiate(
                    extraBallPrefab,
                    ballMain.transform.position,
                    ballMain.transform.rotation,
                    arenaTransform);

            extraBall.GetComponent<BallBehaviorExtra>().PaddleBehaviorAI =
                 paddleBehaviorAI;

            extraBall.GetComponent<Rigidbody>().velocity =
                new Vector3(0, 0, 20);
        }

        timeUntilExtraBalls = (int)Time.time + 5;
    }
}
