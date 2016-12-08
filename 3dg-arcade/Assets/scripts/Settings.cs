using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

internal class Settings : MonoBehaviour
{
    public static Settings settings;

    private object[,] settingsProfiles;

    public const int profilesMax = 5;

    private int profilesActual;

    private const int profileSettingsNum = 1;

    private const int profileNameIndex = 0;

    private int profileIndexPlayerOne = -1;

    private int profileIndexPlayerTwo = -1;

    public string getProfileName(int profileIndex)
    {
        string profileName = null;

        if (profileIndex < profilesMax)
        {
            object maybeProfileName =
                settingsProfiles[profileIndex, profileNameIndex];

            profileName = (string) maybeProfileName;
        }

        return profileName;
    }

    public int getProfileIndexPlayerOne()
    {
        return profileIndexPlayerOne;
    }

    public void setProfileIndexPlayerOne(int profileIndexPlayerOne)
    {
        this.profileIndexPlayerOne = profileIndexPlayerOne;
    }

    public int getProfileIndexPlayerTwo()
    {
        return profileIndexPlayerTwo;
    }

    public void setProfileIndexPlayerTwo(int profileIndexPlayerTwo)
    {
        this.profileIndexPlayerTwo = profileIndexPlayerTwo;
    }

    public void Awake()
    {
        if (settings == null)
        {
            DontDestroyOnLoad(gameObject);
            settings = this;
        }
        else if (settings != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Load();
    }

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/settings.dat"))
        {
            FileStream settingsFile = File.Open(
                Application.persistentDataPath + "/settings.dat",
                FileMode.Open);

            BinaryFormatter deserializer = new BinaryFormatter();
            SettingsSerializable settingsSerializable =
                (SettingsSerializable)deserializer.Deserialize(settingsFile);

            settingsFile.Close();

            settingsProfiles = settingsSerializable.settingsProfiles;
            profilesActual = settingsSerializable.profilesActual;        }

        else
        {
            settingsProfiles = new object[profilesMax, profileSettingsNum];
            settingsProfiles[0, profileNameIndex] = "AI";
            for (int profile = 1; profile < profilesMax; ++profile)
            {
                settingsProfiles[profile, profileNameIndex] = 
                    "<create profile>";
            }
        }
    }

    public void Save()
    {
        FileStream settingsFile = File.Open(
            Application.persistentDataPath + "/settings.dat",
            FileMode.OpenOrCreate);

        SettingsSerializable settingsSerializable = new SettingsSerializable();
        settingsSerializable.settingsProfiles = settingsProfiles;
        settingsSerializable.profilesActual = profilesActual;

        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(settingsFile, settingsSerializable);

        settingsFile.Close();
    }

    public void CreateProfile(string profileName, int profileIndex)
    {
        settingsProfiles[profileIndex, profileNameIndex] = 
            profileName;
        Save();
    }

    [Serializable]
    private class SettingsSerializable
    {
        internal object[,] settingsProfiles;

        internal int profilesActual;
    }
}
