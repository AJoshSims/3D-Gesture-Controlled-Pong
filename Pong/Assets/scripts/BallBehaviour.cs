<<<<<<< Updated upstream
﻿using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    public int speed;

	void Start ()
    {
        InitiateBallMovement();
    }

    void InitiateBallMovement()
    {
        GetComponent<Rigidbody>().AddForce(speed, 0, 0, ForceMode.Impulse);
    }
}
=======
﻿using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    public int speed;

    //public GameObject AIPaddle;

	private void Start ()
    {
        InitiateBallMovement(speed);
    }

    internal void InitiateBallMovement(float xVelocity)
    {
        GetComponent<Rigidbody>().AddForce(xVelocity, 0, 0, ForceMode.Impulse);
    }

    // The stuff below is an attempt at AI.

    //private void FixedUpdate()
    //{
    //    Vector3 AIPaddlePosition =
    //        AIPaddle.GetComponent<Transform>().position;
    //    Vector3 currentBallPosition =
    //        GetComponent<Transform>().position;
    //    AIPaddlePosition = new Vector3(currentBallPosition.x, AIPaddlePosition.y, AIPaddlePosition.z);

    //    Vector3 AIPaddlePosition =
    //        AIPaddle.GetComponent<Transform>().position;
    //    Vector3 currentAIPaddleVelocity = Vector3.zero;
    //    Vector3 currentBallPosition =
    //        GetComponent<Transform>().position;

    //    Vector3.SmoothDamp(
    //        AIPaddlePosition,
    //        currentBallPosition,
    //        ref currentAIPaddleVelocity,
    //        3,
    //        5,
    //        Time.deltaTime);

    //    print(AIPaddlePosition);

    //    StartCoroutine(waitAndMoveAIPaddleToBall());
    //}

    //private IEnumerator waitAndMoveAIPaddleToBall()
    //{
    //    yield return new WaitForSeconds(3);
    //    moveAIPaddleToBall();
    //}

    //private void moveAIPaddleToBall()
    //{
    //    Vector3 currentAIPaddlePosition =
    //        AIPaddle.GetComponent<Transform>().position;
    //    Vector3 currentBallPosition = GetComponent<Transform>().position;

    //    AIPaddle.GetComponent<Transform>().position =
    //        Vector3.MoveTowards(
    //            currentAIPaddlePosition,
    //            currentBallPosition, 1);
    //}

    //private void OnCollisionEnter(Collision collision)
    //{

    //    oh geezmaybe unnecessary
    //    //const int first_contact = 0;

    //    Vector3 ballVelocity = GetComponent<Rigidbody>().velocity;
    //    print(ballVelocity);
    //    //Vector3 normalVectorOfCollision = 
    //    //    collision.contacts[first_contact].normal;

    //    //Vector3.Angle(ballVelocity, normalVectorOfCollision);

    //    // phantomBall
    //    //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    //sphere.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
    //    //sphere.GetComponent<Transform>().position = GetComponent<Transform>().position;
    //    //sphere.AddComponent<Rigidbody>();
    //    //sphere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    //    //sphere.GetComponent<Collider>().enabled = false;
    //    //sphere.GetComponent<Rigidbody>().velocity = ballVelocity * 2;
    //}
}
>>>>>>> Stashed changes
