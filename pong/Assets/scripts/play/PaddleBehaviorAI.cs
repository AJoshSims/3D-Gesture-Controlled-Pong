using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviorAI : MonoBehaviour, MutableSize
{
    private Queue<GameObject> ballsToPursue = null;

    public enum ArtificialIntelligenceLevel
    {
        Low, Medium, High
    }

    public ArtificialIntelligenceLevel artificalIntelligenceLevelSelected;

    private float speed;

    private bool sizeChanged;

    private Vector3 originalSize;

    private float timeUntilOriginalSize;

    internal void AddBallToQueue(GameObject ball)
    {
        ballsToPursue.Enqueue(ball);
    }

    private void Awake()
    {
        ballsToPursue = new Queue<GameObject>(5);

        sizeChanged = false;

        originalSize = transform.localScale;

        timeUntilOriginalSize = 0;
    }

    private void Start ()
    {
        switch (artificalIntelligenceLevelSelected)
        {
            case ArtificialIntelligenceLevel.High:
                speed = 30;
                break;
            case ArtificialIntelligenceLevel.Medium:
                speed = 5;
                break;
            case ArtificialIntelligenceLevel.Low:
                speed = 3;
                break;
        }

        transform.localPosition = new Vector3(0, 0, 30);
	}
	
	private void FixedUpdate ()
    {
        if (ballsToPursue.Count > 0)
        {
            GameObject ballTarget = ballsToPursue.Peek();

            if (ballTarget != null)
            {
               BallBehavior ballTargetBehavior = 
                    ballTarget.GetComponent<BallBehavior>();

                if (ballTargetBehavior.ToBePursued == true)
                {
                    transform.localPosition = Vector3.MoveTowards(
                        transform.localPosition,
                        new Vector3(
                        ballTarget.transform.localPosition.x, 
                        ballTarget.transform.localPosition.y, 
                        30),
                        speed * Time.deltaTime);
                }

                else
                {
                    ballsToPursue.Dequeue();
                }
            }

            else
            {
                ballsToPursue.Dequeue();
            }
        }

        else
        {
            transform.localPosition = Vector3.MoveTowards(
                transform.localPosition,
                new Vector3(0, 0, 30),
                speed * Time.deltaTime);
        }

        if ((sizeChanged == true) && (Time.time > timeUntilOriginalSize))
        {
            transform.localScale = originalSize;

            sizeChanged = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.collider.gameObject;

        BallBehavior ballBehavior = collidedWith.GetComponent<BallBehavior>();

        if (ballBehavior != null)
        {
            if (ballsToPursue.Count > 0 
                && collidedWith == ballsToPursue.Peek())
            {
                ballsToPursue.Dequeue();
                ballBehavior.ToBePursued = false;
                ballBehavior.IsAway = true;
            }

            else if(ballBehavior.ToBePursued == true)
            {
                ballBehavior.ToBePursued = false;
                ballBehavior.IsAway = true;
            }
        }
    }

    public void mutateSize(float value, float timeUntilOriginalSize)
    {
        transform.localScale = transform.localScale * value;

        this.timeUntilOriginalSize = timeUntilOriginalSize;

        sizeChanged = true;
    }
}
