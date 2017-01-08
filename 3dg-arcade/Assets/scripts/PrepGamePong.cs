using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrepGamePong : MonoBehaviour
{
    public Dropdown playerOneDropdown;

    public Dropdown playerTwoDropdown;

    public void SetProfileIndicesForPlayers()
    {
        Settings.settings.setProfileIndexPlayerOne(playerOneDropdown.value);
        Settings.settings.setProfileIndexPlayerTwo(playerTwoDropdown.value);
    }
}
