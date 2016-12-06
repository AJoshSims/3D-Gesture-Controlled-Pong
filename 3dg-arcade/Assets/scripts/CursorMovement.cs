using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class CursorMovement : MonoBehaviour
{
    private GameObject RightHand;


    void Start()
    {
    }

    void Update()
    {
        if (RightHand == null)
        {
            RightHand = GameObject.Find("HandRight");
        }
        else
        {
            gameObject.transform.position = new Vector3(RightHand.transform.position.x, RightHand.transform.position.y,
                RightHand.transform.position.z);
        }
    }
}
