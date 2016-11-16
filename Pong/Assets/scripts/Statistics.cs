using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Statistics : MonoBehaviour
{
    public static Statistics statistics;

    public int wins;

    void Awake()
    {
        if (statistics == null)
        {
            DontDestroyOnLoad(gameObject);
            statistics = this;
        }
        else if (statistics != this)
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        FileStream statisticsFile = File.Open(
            Application.persistentDataPath + "/statistics.dat", 
            FileMode.OpenOrCreate);

        StatisticsSerializable statisticsSerializable = 
            new StatisticsSerializable();
        statisticsSerializable.wins = wins;
        
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(statisticsFile, statisticsSerializable);

        statisticsFile.Close();       
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/statistics.dat"))
        {
            FileStream statisticsFile = File.Open(
                Application.persistentDataPath + "/statistics.dat", 
                FileMode.Open);

            BinaryFormatter deserializer = new BinaryFormatter();

            StatisticsSerializable statisticsSerializable =
                (StatisticsSerializable) deserializer.Deserialize(
                statisticsFile);
            statisticsFile.Close();
        }
    }

    [Serializable]
    private class StatisticsSerializable
    {
        internal int wins;
    }
}
