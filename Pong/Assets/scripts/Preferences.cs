using UnityEngine;
using System.Collections;

public class Preferences : MonoBehaviour
{
    public static Preferences preferences;

    public static int toWin = 5;

    private void Awake()
    {
        if (preferences == null)
        {
            DontDestroyOnLoad(gameObject);
            preferences = this;
        }
        else if (preferences != this)
        {
            Destroy(gameObject);
        }
    }
}
