using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviorAI : MonoBehaviour
{
    private Queue<GameObject> balls = null;

    public enum ArtificialIntelligenceLevel
    {
        Low, Medium, High
    }

    public ArtificialIntelligenceLevel artificalIntelligenceLevelSelected;

    private float speed;

    internal void AddBallToQueue(GameObject ball)
    {
        balls.Enqueue(ball);
    }

    internal void removeBallFromQueue()
    {
        if ((balls.Count > 0) && (balls.Peek() != null))
        {
            GameObject ballTargeted = balls.Dequeue();

            BallBehavior ballBehaviour =
                ballTargeted.GetComponent<BallBehavior>();

            ballBehaviour.setHasAlertedArtificialIntelligence();
            ballBehaviour.setHasBeenHitByAI();
        }
    }

    private void Awake()
    {
        balls = new Queue<GameObject>(5);
    }

    private void Start ()
    {
        switch (artificalIntelligenceLevelSelected)
        {
            case ArtificialIntelligenceLevel.High:
                speed = 30;
                break;
            case ArtificialIntelligenceLevel.Medium:
                speed = 20;
                break;
            case ArtificialIntelligenceLevel.Low:
                speed = 10;
                break;
        }

        transform.localPosition = new Vector3(0, 0, 30);
	}
	
	private void FixedUpdate ()
    {
        if (balls.Count > 0)
        {
            GameObject ballTarget = balls.Peek();

            if (ballTarget != null)
            {
                transform.localPosition = Vector3.MoveTowards(
                    transform.localPosition,
                    new Vector3(
                    ballTarget.transform.localPosition.x, 
                    ballTarget.transform.localPosition.y, 
                    30),
                    speed * Time.deltaTime);
            }
        }

        else
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition,
                new Vector3(0, 0, 30),
                speed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if ((balls.Count > 0) && (balls.Peek() != null))
        {
            GameObject ballTargeted = balls.Dequeue();

            ballTargeted.GetComponent<BallBehavior>()
                .setHasBeenHitByAI();
        }
    }
}
