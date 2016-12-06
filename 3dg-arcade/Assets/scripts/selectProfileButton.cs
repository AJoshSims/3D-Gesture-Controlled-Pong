using UnityEngine;
using System.Collections;

public class selectProfileButton : MonoBehaviour
{
    public GameObject inputField;

    private void Awake()
    {
        inputField.SetActive(false);
    }

    public void inputProfileName()
    {
        
        gameObject.SetActive(false);
        inputField.SetActive(true);
    }
}
