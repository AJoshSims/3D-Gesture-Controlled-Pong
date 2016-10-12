using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUIPlayerOne : MonoBehaviour {
    public Text ScoreBoard;
    GameObject ball;
    private int scoreOne = 0;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
	
	}
	
	// Update is called once per frame
	void Update () {

        if (ball.transform.position.x <= -9.585f)
        {
            scoreOne++;
        }

        ScoreBoard.text = "Player One: " + scoreOne.ToString();
        print("Player One: " + scoreOne);
	}
}
