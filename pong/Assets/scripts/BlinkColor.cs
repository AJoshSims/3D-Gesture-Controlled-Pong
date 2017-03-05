using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkColor : MonoBehaviour
{
    private bool blinkActive;

    private float timeSinceLastBlink;

    private const float timeBetweenBlinks = 0.5F;

    private Color nextColor;

    private Color originalColor;

    public Color blinkColor;

    internal void setBlinkActive(bool blinkActive)
    {
        this.blinkActive = blinkActive;

        if (blinkActive == false)
        {
            GetComponent<MeshRenderer>().material.color = originalColor;
        }
    }

    private void Awake()
    {
        originalColor = GetComponent<MeshRenderer>().material.color;
        nextColor = blinkColor;
    }

    void Update()
    {
        if ((blinkActive == true)
            && ((Time.time - timeSinceLastBlink) > timeBetweenBlinks))
        {
            Color temp = GetComponent<MeshRenderer>().material.color;
            GetComponent<MeshRenderer>().material.color = nextColor;
            nextColor = temp;
            timeSinceLastBlink = Time.time;
        }
    }
}