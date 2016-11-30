using UnityEngine;
using UnityEngine.UI;

internal class selectProfile : MonoBehaviour
{
    Dropdown dropDown;

    private void Start()
    {
        dropDown = this.gameObject.GetComponent<Dropdown>();
    }

    internal void select()
    {
        string profileChoice = this.gameObject.GetComponent<Text>().text;
        if (profileChoice.Equals("<create profile>"))
        {

        }
    }
}
