using UnityEngine;
using System.Collections;

public class createProfile : MonoBehaviour
{
    public GameObject inputField;

    private void Awake()
    {
        inputField.SetActive(false);
    }

    public void Create()
    {
        gameObject.SetActive(false);
        inputField.SetActive(true);
    }
}
