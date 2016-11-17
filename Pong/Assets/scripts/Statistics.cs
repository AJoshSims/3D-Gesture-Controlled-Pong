using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Statistics : MonoBehaviour
{
    public static Statistics statistics;

    public int player01Goals;

    public int player01Wins;

    public int player01Losses;

    public int player02Goals;

    public int player02Wins;

    public int player02Losses;

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
        statisticsSerializable.player01Goals = player01Goals;
        statisticsSerializable.player01Wins = player01Wins;
        statisticsSerializable.player01Losses = player01Losses;
        statisticsSerializable.player02Goals = player02Goals;
        statisticsSerializable.player02Wins = player02Wins;
        statisticsSerializable.player02Losses = player02Losses;

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

            player01Goals = statisticsSerializable.player01Goals;
            player01Wins = statisticsSerializable.player01Wins;
            player01Losses = statisticsSerializable.player01Losses;
            player02Goals = statisticsSerializable.player02Goals;
            player02Wins = statisticsSerializable.player02Wins;
            player02Losses = statisticsSerializable.player02Losses;
        }
    }

    [Serializable]
    private class StatisticsSerializable
    {
        internal int player01Goals;

        internal int player01Wins;

        internal int player01Losses;

        internal int player02Goals;

        internal int player02Wins;

        internal int player02Losses;
    }
}
