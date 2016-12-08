using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

internal class selectProfileDropdown : MonoBehaviour
{
    private Dropdown thisDropdown;

    public Dropdown playerOneDropdown;

    public Dropdown playerTwoDropdown;

    public Text profileSelected;

    public InputField inputField;

    public Text placeholder;

    public Text profileEntered;

    private Vector3 originalPosition;

    private string originalPlaceholderText;

    private void Awake()
    {
        inputField.transform.position = new Vector3(-999, -999, -999);
    }

    private void Start()
    {
        thisDropdown = gameObject.GetComponent<Dropdown>();

        for (
            int profileIndex = 0;
            profileIndex < thisDropdown.options.Count;
            ++profileIndex)
        {
            thisDropdown.options[profileIndex] =
                new Dropdown.OptionData(
                Settings.settings.getProfileName(profileIndex));
        }

        originalPlaceholderText = placeholder.text;
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

        bool invalidProfileEntered = false;
        if (profileEnteredLower.Equals(""))
        {
            invalidProfileEntered = true;
        }
        foreach (Dropdown.OptionData profile in thisDropdown.options)
        {
            if (profile.text.ToLower().Equals(profileEnteredLower))
            {
                invalidProfileEntered = true;
            }
        }
        if (invalidProfileEntered == true)
        {
            placeholder.text = "unavailable";
            inputFieldClearable.text = "";
            inputField.ActivateInputField();
            return;
        }

        playerOneDropdown.options[thisDropdown.value] =
            new Dropdown.OptionData(profileEntered.text);
        playerTwoDropdown.options[thisDropdown.value] =
            new Dropdown.OptionData(profileEntered.text);
        Settings.settings.CreateProfile(
            profileEntered.text, thisDropdown.value);

        placeholder.text = originalPlaceholderText;
        inputFieldClearable.text = "";
        inputField.transform.position = new Vector3(-999, -999, -999);
        gameObject.transform.position = originalPosition;
        thisDropdown.itemText = profileEntered;
    }
}
