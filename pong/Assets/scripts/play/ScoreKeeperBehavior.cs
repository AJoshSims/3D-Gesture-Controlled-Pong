using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperBehavior : MonoBehaviour
{
    public static ScoreKeeperBehavior scoreKeeperBehavior;

    private int scorePlayer01;

    public Text scorePlayer01Text;

    private const string scorePlayer01Prefix = "Player 1: ";

    private int scorePlayer02;

    public Text scorePlayer02Text;

    private const string scorePlayer02Prefix = "Player 2: ";

    private void Awake()
    {
        if (scoreKeeperBehavior == null)
        {
            scoreKeeperBehavior = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scorePlayer01 = 0;
        scorePlayer01Text.text = scorePlayer01Prefix + scorePlayer01;

        scorePlayer02 = 0;
        scorePlayer02Text.text = scorePlayer02Prefix + scorePlayer02; 
    }

    internal void incrementScore(bool player01, int value)
    {
        if (player01 == true)
        {
            scorePlayer01 = scorePlayer01 + value;
            scorePlayer01Text.text = scorePlayer01Prefix + scorePlayer01;
        }
        else
        {
            scorePlayer02 = scorePlayer02 + value;
            scorePlayer02Text.text = scorePlayer02Prefix + scorePlayer02;
        }
    }
}
