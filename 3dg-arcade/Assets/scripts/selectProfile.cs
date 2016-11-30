using UnityEngine;
using UnityEngine.UI;

internal class selectProfile : MonoBehaviour
{
    public Dropdown dropDown;

    public Text profileSelected;

    public GameObject inputField;

    public Text placeHolder;

    public Text profileEntered;

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

    public void Create()
    {
        foreach (Dropdown.OptionData profile in dropDown.options)
        {
            if (profile.text.Equals(profileEntered.text))
            {
                placeHolder.text = "unavailable";
                InputField inputField = 
                    this.inputField.GetComponent<InputField>();
                inputField.text = "";
            }
        }
    }
}
