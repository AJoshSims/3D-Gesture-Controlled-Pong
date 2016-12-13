using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class DetectJoint : MonoBehaviour
{
    private GameObject rightHand;

    void Update()
    {
        if(rightHand == null)
        {
            rightHand = GameObject.Find("HandRight");
        }

        else
        {
            gameObject.transform.position = 
                new Vector3(0, 0, rightHand.transform.position.z);
        }
    }
}