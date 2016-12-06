using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour
{
    public static Settings settings;

    private void Awake()
    {
        if (settings == null)
        {
            DontDestroyOnLoad(gameObject);
            settings = this;
        }
        else if (settings != this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        Load();
    }
}
