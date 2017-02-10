using UnityEngine;
using System;
using System.Collections;
using Windows.Kinect;

public class PaddleBehaviourPlayer : MonoBehaviour
{
    private GameObject rightHand;

    void FixedUpdate()
    {
        if (rightHand == null)
        {
            rightHand = GameObject.Find("HandRight");
        }

        else
        {
            gameObject.transform.position = new Vector3
                (rightHand.transform.position.x,
                rightHand.transform.position.y,
                -10);
        }
    }
}
