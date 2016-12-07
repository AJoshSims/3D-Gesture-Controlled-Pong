using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

internal class selectProfileDropdown : MonoBehaviour
{
    public Dropdown playerOneDropdown;

    public Dropdown playerTwoDropdown;

    public Text profileSelected;

    public InputField inputField;

    public Text placeholder;

    public Text profileEntered;

    private Vector3 originalPosition;

    private void Awake()
    {
        inputField.transform.position = new Vector3(-999, -999, -999);
    }

    public void Select()
    {
        if (profileSelected.text.Equals("<create profile>"))
        {
            originalPosition = gameObject.transform.position;
            gameObject.transform.position = new Vector3(-999, -999, -999);

            inputField.transform.position = originalPosition;
            inputField.ActivateInputField();
        }
    }

    public void Create()
    {
        InputField inputFieldClearable = 
            inputField.GetComponent<InputField>();

        string profileEnteredLower = profileEntered.text.ToLower();
        foreach (Dropdown.OptionData profile in playerOneDropdown.options)
        {
            if (profile.text.ToLower().Equals(profileEnteredLower))
            {
                placeholder.text = "unavailable";

                inputFieldClearable.text = "";
                return;
            }
        }

        // TODO error handling
        //playerTwoDropdown.options[playerOneDropdown.value] =
        //    new Dropdown.OptionData(profileEntered.text);
        playerOneDropdown.options[playerOneDropdown.value] =
            new Dropdown.OptionData(profileEntered.text);
        inputFieldClearable.text = "";
        inputField.transform.position = new Vector3(-999, -999, -999);
        gameObject.transform.position = originalPosition;
        playerOneDropdown.itemText = profileEntered;
    }
}
