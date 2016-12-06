using UnityEngine;
using UnityEngine.UI;

internal class selectProfileDropdown : MonoBehaviour
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
            //this.gameObject.SetActive(false);
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

                InputField inputFieldClearable = 
                    this.inputField.GetComponent<InputField>();
                inputFieldClearable.text = dropDown.options[dropDown.value].text;
                return;
            }
        }

        dropDown.options[dropDown.value] = 
            new Dropdown.OptionData(profileEntered.text);
        inputField.SetActive(false);
        //this.gameObject.SetActive(true);
    }
}
