using UnityEngine;
using UnityEngine.UI;

internal class selectProfile : MonoBehaviour
{
    public Dropdown dropDown;

    public Text label;

    public GameObject inputField;

    private void Awake()
    {
        this.inputField.SetActive(false);
    }

    public void Select()
    {
        string profileChoice = label.text;
        if (profileChoice.Equals("<create profile>"))
        {
            dropDown.Hide();
        }
    }
}
