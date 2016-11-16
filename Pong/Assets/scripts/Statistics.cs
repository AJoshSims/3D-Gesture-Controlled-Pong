using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Statistics : MonoBehaviour
{
    public static Statistics statistics;

    public int player01Wins;

    public int player02Wins;

    public GameObject goal;

    private void Awake()
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

    public void Start()
    {
        Load();
    }

    public void Save()
    {
        FileStream statisticsFile = File.Open(
            Application.persistentDataPath + "/statistics.dat", 
            FileMode.OpenOrCreate);

        StatisticsSerializable statisticsSerializable = 
            new StatisticsSerializable();
        statisticsSerializable.player01Wins = player01Wins;
        statisticsSerializable.player02Wins = player02Wins;
        
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

            player01Wins = statisticsSerializable.player01Wins;
            player02Wins = statisticsSerializable.player02Wins;
        }
    }

    [Serializable]
    private class StatisticsSerializable
    {
        internal int player01Wins;

        internal int player02Wins;
    }
}
