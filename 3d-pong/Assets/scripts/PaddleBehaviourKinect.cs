using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class PaddleBehaviourKinect : MonoBehaviour
{
    private JointType jointId = JointType.HandRight;
    private float easing = 0.1f;

    private Transform tr;

	void Start ()
    {
        tr = GetComponent<Transform>();
	}

    void Update()
    {
        if (BodySourceView.bodyTracked)
        {
            Vector3 joint = BodySourceView.jointObjs[(int)jointId].position;

            float targetX = joint.x;
            float posX = tr.position.x;
            float dx = targetX - posX;
            if (Mathf.Abs(dx) > 1)
            {
                posX += dx * easing;
            }

            float targetY = joint.y;
            float posY = tr.position.y;
            float dy = targetY - posY;
            if (Mathf.Abs(dy) > 1)
            {
                posY += dy * easing;
            }

            float targetZ = -joint.z;
            float posZ = tr.position.z;
            float dz = targetZ - posZ;
            if (Mathf.Abs(dz) > 1)
            {
                posZ += dz * easing;
            }

            tr.position = new Vector3(posX, posY, posZ);
        }
    }
}
