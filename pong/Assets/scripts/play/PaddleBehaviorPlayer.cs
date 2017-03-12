using UnityEngine;
using System;
using System.Collections;
using Windows.Kinect;

public class PaddleBehaviorPlayer : MonoBehaviour, MutableSize
{
    private GameObject rightHand;

    private bool sizeChanged;

    private float timeUntilOriginalSize;

    private Vector3 originalSize;

    private void Awake()
    {
        sizeChanged = false;

        originalSize = transform.localScale;

        timeUntilOriginalSize = 0;
    }

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

        if ((sizeChanged == true) && (Time.time > timeUntilOriginalSize))
        {
            transform.localScale = originalSize;

            sizeChanged = false;
        }
    }

    public void mutateSize(float value, float timeUntilOriginalSize)
    {
        transform.localScale = transform.localScale * value;

        this.timeUntilOriginalSize = timeUntilOriginalSize;

        sizeChanged = true;
    }
}
