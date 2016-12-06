using UnityEngine;
using UnityEngine.UI;

internal class selectProfileDropdown : MonoBehaviour
{
    public Dropdown dropDown;

    public Text profileSelected;

    public GameObject inputField;

    public Text placeHolder;

    public Text profileEntered;

    private Vector3 originalPosition;

    private string originalPlaceHolderText;

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
        }
    }

    public void Create()
    {
        InputField inputFieldClearable = 
            inputField.GetComponent<InputField>();

        string profileEnteredLower = profileEntered.text.ToLower();
        foreach (Dropdown.OptionData profile in dropDown.options)
        {
            if (profile.text.ToLower().Equals(profileEnteredLower))
            {
                originalPlaceHolderText = placeHolder.text;
                placeHolder.text = "unavailable";

                inputFieldClearable.text = "";
                return;
            }
        }

        dropDown.options[dropDown.value] =
            new Dropdown.OptionData(profileEntered.text);
        inputFieldClearable.text = "";
        inputField.transform.position = new Vector3(-999, -999, -999);
        gameObject.transform.position = originalPosition;
        dropDown.itemText = profileEntered;
    }
}
