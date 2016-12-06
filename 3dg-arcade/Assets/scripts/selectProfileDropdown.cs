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

    private void Awake()
    {
        this.inputField.SetActive(false);
    }

    public void Select()
    {
        if (profileSelected.text.Equals("<create profile>"))
        {
            originalPosition = gameObject.transform.position;
            gameObject.transform.position = new Vector3(-999, -999, -999);
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
                inputFieldClearable.text = "";
                return;
            }
        }

        inputField.SetActive(false);
        gameObject.transform.position = originalPosition;
        dropDown.options[dropDown.value] = 
            new Dropdown.OptionData(profileEntered.text);
    }
}
