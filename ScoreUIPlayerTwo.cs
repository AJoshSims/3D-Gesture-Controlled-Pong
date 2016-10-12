using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUIPlayerTwo : MonoBehaviour
{
    public Text ScoreBoardO;
    GameObject ball;
    private int scoreTwo = 0;

    // Use this for initialization
    void Start()
    {
        ball = GameObject.Find("Ball");

    }

    // Update is called once per frame
    void Update()
    {

        if (ball.transform.position.x >= 9.42f)
        {
            scoreTwo++;
        }

        ScoreBoardO.text = "Player Two: " + scoreTwo.ToString();
        print("Player Two: " + scoreTwo);
    }
}