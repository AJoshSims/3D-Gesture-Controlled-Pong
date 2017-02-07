using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviourAI : MonoBehaviour
{
    // Change this because we need to accomodate multiple balls.
    // We are going to need a queue.
    public GameObject ball;

    public enum ArtificialIntelligenceLevel
    {
        Low, Medium, High
    }

    public ArtificialIntelligenceLevel artificalIntelligenceLevelSelected;

    private float speed;

    void Start ()
    {
        switch (artificalIntelligenceLevelSelected)
        {
            case ArtificialIntelligenceLevel.High:
                speed = 50;
                break;
            case ArtificialIntelligenceLevel.Medium:
                speed = 30;
                break;
            case ArtificialIntelligenceLevel.Low:
                speed = 20;
                break;
        }

        transform.localPosition = new Vector3(0, 0, 30);
	}
	
	void FixedUpdate ()
    {
        if (transform.localPosition.z > 2)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                ball.transform.position,
                speed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.position,
                new Vector3(0, 0, 30),
                speed * Time.deltaTime);
        }
	}
}
