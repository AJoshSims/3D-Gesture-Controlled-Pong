using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExtraBalls : MonoBehaviour
{
    public static EffectExtraBalls effectExtraBalls;

    private Settings.GameplayEffectMode mode;

    private int timeUntilBallExtras;

    private System.Random randomNumGenerator;

    private const int maxNumOfBallsExtras = 4;

    private BallBehaviorExtra[] ballExtras;

    private bool canSpawnBallsExtra;

    public PaddleBehaviorAI paddleBehaviorAI;

    public Transform arenaTransform;

    public Object extraBallPrefab;

    public GameObject ballMain;

    private bool ballMainBlinking;

    internal Settings.GameplayEffectMode Mode
    {
        get
        {
            return mode;
        }

        set
        {
            mode = value;
        }
    }

    internal void prepareBallExtra(
        BallBehaviorExtra ballExtra, 
        int ballExtraIndex)
    {
        ballExtras[ballExtraIndex] = ballExtra;
    }

    internal void confirmCanSpawnBallsExtra()
    {
        canSpawnBallsExtra = true;   
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

        ballExtras = new BallBehaviorExtra[maxNumOfBallsExtras];

        canSpawnBallsExtra = true;

        randomNumGenerator = new System.Random();

        // timeUntilExtraBalls = randomNumGenerator.Next(30, 61);

        ballMainBlinking = false;
    }

    private void Start()
    {
        if (Settings.settings.getGameplayEffectMode(
            Settings.extraBalls)
            == Settings.GameplayEffectMode.Immediate)
        {
            enabled = true;
        }
        else
        {
            enabled = false;
        }

        timeUntilBallExtras = 5;
    }

    private void Update()
    {
        if (
            (Time.time > timeUntilBallExtras) 
            && (ballMainBlinking == false)
            && (canSpawnBallsExtra == true))
        {
            ballMainBlinking = true;

            StartCoroutine(waitAndSpawnBallsExtra());
        }
    }

    private IEnumerator waitAndSpawnBallsExtra()
    {
        BlinkColor ballMainBlink = ballMain.GetComponent<BlinkColor>();
        ballMainBlink.setBlinkActive(true);

        yield return new WaitForSecondsRealtime(2);

        ballMainBlink.setBlinkActive(false);

        ballMainBlinking = false;

        spawnBallsExtra();
    }

    private void spawnBallsExtra()
    {
        int numOfBallsExtraActive = 0;

        int ballExtraIndex = 0;

        for (
            ballExtraIndex = 0; 
            ballExtraIndex < maxNumOfBallsExtras; 
            ++ballExtraIndex)
        {
            if (ballExtras[ballExtraIndex].Active == true)
            {
                ++numOfBallsExtraActive;
            }
        }

        int numOfBallsExtraToActivate = randomNumGenerator.Next(
            1, maxNumOfBallsExtras - numOfBallsExtraActive);

        if (
            (numOfBallsExtraToActivate + numOfBallsExtraActive) 
            == maxNumOfBallsExtras)
        {
            canSpawnBallsExtra = false;
        }

        for (
            ballExtraIndex = 0; 
            (ballExtraIndex < maxNumOfBallsExtras)
            && (numOfBallsExtraToActivate > 0); 
            ++ballExtraIndex)
        {
            if (ballExtras[ballExtraIndex].Active == false)
            {
                ballExtras[ballExtraIndex].Activate();
                --numOfBallsExtraToActivate;
            }
        }

        timeUntilBallExtras = (int)Time.time + 5;
    }
}
