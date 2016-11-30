using UnityEngine;
using UnityEngine.UI;

internal class selectProfile : MonoBehaviour
{
    public Dropdown dropDown;

    public Text profileSelected;

    public GameObject inputField;

    private void Awake()
    {
        this.inputField.SetActive(false);
    }

    public void Select()
    {
        if (profileSelected.text.Equals("<create profile>"))
        {
            this.gameObject.SetActive(false);
            inputField.SetActive(true);
        }
    }
}
