using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class DetectJoint : MonoBehaviour
{
    private GameObject RightHand;


    void Start() {
    }

    void Update()
    {
        if(RightHand == null)
        {
            RightHand = GameObject.Find("HandRight");
        }
        else
        {
            gameObject.transform.position = new Vector3(0, 0,
                RightHand.transform.position.z);
        }
    }
}