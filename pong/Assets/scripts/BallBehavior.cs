using UnityEngine;
using System.Collections;

public class BallBehavior : MonoBehaviour
{
    private const float beginningXPositionOfBall = 0;
    private const float beginningYPositionOfBall = 0;
    private const float beginningZPositionOfBall = 0;

    public int speed;

    private const float zPositionGoalZonePlayer01 = -39;
    private const float zPositionGoalZonePlayer02 = 39;

    // Will need this for statistics collection.
    //public static GameObject goalZoneSegmentPlayer0101;
    //public static GameObject goalZoneSegmentPlayer0102;
    //public static GameObject goalZoneSegmentPlayer0103;
    //public static GameObject goalZoneSegmentPlayer0104;

    //public static GameObject goalZoneSegmentPlayer0201;
    //public static GameObject goalZoneSegmentPlayer0202;
    //public static GameObject goalZoneSegmentPlayer0203;
    //public static GameObject goalZoneSegmentPlayer0204;

    public GameObject paddleArtificialIntelligence;

    private PaddleBehaviorAI paddleBehaviourAI;

    private bool hasAlertedArtificialIntelligence;

    private bool hasBeenHitByAI;

    internal void setHasAlertedArtificialIntelligence()
    {
        hasAlertedArtificialIntelligence = false;
    }

    internal void setHasBeenHitByAI()
    {
        hasBeenHitByAI = true;
    }

    private void Start()
    {
        paddleBehaviourAI = 
            paddleArtificialIntelligence.GetComponent<PaddleBehaviorAI>();

        hasAlertedArtificialIntelligence = false;
        hasBeenHitByAI = false;

        StartCoroutine(WaitAndInitiateBallMovement(zPositionGoalZonePlayer01));
    }

    private void FixedUpdate()
    {
        if (
            (hasAlertedArtificialIntelligence == false)
            && (transform.position.z > 1))
        {
            paddleBehaviourAI.AddBallToQueue(this.gameObject);
            hasAlertedArtificialIntelligence = true;
        }

        else if (hasBeenHitByAI == true && transform.position.z <= 1)
        {
            hasAlertedArtificialIntelligence = false;
            hasBeenHitByAI = false;
        }
    }

    private void ResetBall(float zPositionGoalZone)
    {
        transform.position = new Vector3(
            beginningXPositionOfBall,
            beginningYPositionOfBall,
            beginningZPositionOfBall);

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        StartCoroutine(WaitAndInitiateBallMovement(zPositionGoalZone));
    }

    private IEnumerator WaitAndInitiateBallMovement(float zPositionGoalZone)
    {
        yield return new WaitForSecondsRealtime(2);

        InitiateBallMovement(zPositionGoalZone);
    }

    internal void InitiateBallMovement(float zPositionGoalZone)
    {
        // TODO reset to normal
        //const float xVelocityOfZero = 0;
        //const float yVelocityOfZero = 0;
        //GetComponent<Rigidbody>().velocity = new Vector3(
        //    xVelocityOfZero, 
        //    yVelocityOfZero, 
        //    speed * Mathf.Sign(zPositionGoalZone));
        const float xVelocityOfZero = 5;
        const float yVelocityOfZero = 2;
        GetComponent<Rigidbody>().velocity = new Vector3(
            xVelocityOfZero,
            yVelocityOfZero,
            speed * 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.collider.gameObject;

        GoalZoneSegmentBehavior goalZoneSegmentBehaviour =
            collidedWith.GetComponent<GoalZoneSegmentBehavior>();

        if (goalZoneSegmentBehaviour != null)
        {
            if (goalZoneSegmentBehaviour.isAbleToConsumeBall())
            {
                ResetBall(-collidedWith.transform.position.z);
                paddleBehaviourAI.removeBallFromQueue();
            }
        }

        // Else if it was an additive effect object...
    }
}