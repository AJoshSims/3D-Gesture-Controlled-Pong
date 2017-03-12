using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPaddleSize : MonoBehaviour
{
    private static EffectPaddleSize effectPaddleSize;

    private System.Random randomNumGenerator;

    private int timeUntilPaddleSizeChange;

    public GameObject paddlePlayer01;

    public GameObject paddlePlayer02;

    private void Awake()
    {
        if (effectPaddleSize == null)
        {
            effectPaddleSize = this;
        }
        else
        {
            Destroy(gameObject);
        }

        randomNumGenerator = new System.Random();

        //timeUntilPaddleSizeChange =
        //(int) Time.time + randomNumGenerator.Next(30, 61);

        timeUntilPaddleSizeChange = (int)Time.time + 2;
    }

    private void Update()
    {
        if (Time.time > timeUntilPaddleSizeChange)
        {
            MutableSize paddle = null;

            if (randomNumGenerator.NextDouble() > 0.5)
            {
                paddle = paddlePlayer01.GetComponent<PaddleBehaviorPlayer>();
            }
            else
            {
                paddle = paddlePlayer02.GetComponent<PaddleBehaviorAI>();
            }

            paddle.mutateSize(0.5F, randomNumGenerator.Next(10, 21) + 0.0F);

            timeUntilPaddleSizeChange = randomNumGenerator.Next(30, 61);
        }
    }
}
