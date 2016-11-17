using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

internal class Statistics : MonoBehaviour
{
    public static Statistics statistics;

    internal float pongPlayer01Displacement;

    internal int pongPlayer01Hits;

    internal int pongPlayer01WinGoals;

    internal int pongPlayer01WinGoalsLeft;

    internal int pongPlayer01WinGoalsMiddle;

    internal int pongPlayer01WinGoalsRight;

    internal int pongPlayer01Wins;

    internal int pongPlayer01LossGoals;

    internal int pongPlayer01LossGoalsLeft;

    internal int pongPlayer01LossGoalsMiddle;

    internal int pongPlayer01LossGoalsRight;

    internal int pongPlayer01Losses;

    internal float pongPlayer02Displacement;

    internal int pongPlayer02Hits;

    internal int pongPlayer02WinGoals;

    internal int pongPlayer02WinGoalsLeft;

    internal int pongPlayer02WinGoalsMiddle;

    internal int pongPlayer02WinGoalsRight;

    internal int pongPlayer02Wins;

    internal int pongPlayer02LossGoals;

    internal int pongPlayer02LossGoalsLeft;

    internal int pongPlayer02LossGoalsMiddle;

    internal int pongPlayer02LossGoalsRight;

    internal int pongPlayer02Losses;

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
        statisticsSerializable.pongPlayer01Displacement =
            pongPlayer01Displacement;
        statisticsSerializable.pongPlayer01Hits =
            pongPlayer01Hits;
        statisticsSerializable.pongPlayer01WinGoals =
            pongPlayer01WinGoals;
        statisticsSerializable.pongPlayer01WinGoalsLeft =
            pongPlayer01WinGoalsLeft;
        statisticsSerializable.pongPlayer01WinGoalsMiddle =
            pongPlayer01WinGoalsMiddle;
        statisticsSerializable.pongPlayer01WinGoalsRight =
            pongPlayer01WinGoalsRight;
        statisticsSerializable.pongPlayer01Wins =
            pongPlayer01Wins;
        statisticsSerializable.pongPlayer01LossGoals =
            pongPlayer01LossGoals;
        statisticsSerializable.pongPlayer01LossGoalsLeft =
            pongPlayer01LossGoalsLeft;
        statisticsSerializable.pongPlayer01LossGoalsMiddle =
            pongPlayer01LossGoalsMiddle;
        statisticsSerializable.pongPlayer01LossGoalsRight =
            pongPlayer01LossGoalsRight;
        statisticsSerializable.pongPlayer01Losses =
            pongPlayer01Losses;
        statisticsSerializable.pongPlayer02Displacement =
            pongPlayer02Displacement;
        statisticsSerializable.pongPlayer02Hits =
            pongPlayer02Hits;
        statisticsSerializable.pongPlayer02WinGoals =
            pongPlayer02WinGoals;
        statisticsSerializable.pongPlayer02WinGoalsLeft =
            pongPlayer02WinGoalsLeft;
        statisticsSerializable.pongPlayer02WinGoalsMiddle =
            pongPlayer02WinGoalsMiddle;
        statisticsSerializable.pongPlayer02WinGoalsRight =
            pongPlayer02WinGoalsRight;
        statisticsSerializable.pongPlayer02Wins =
            pongPlayer02Wins;
        statisticsSerializable.pongPlayer02LossGoals =
            pongPlayer02LossGoals;
        statisticsSerializable.pongPlayer02LossGoalsLeft =
            pongPlayer02LossGoalsLeft;
        statisticsSerializable.pongPlayer02LossGoalsMiddle =
            pongPlayer02LossGoalsMiddle;
        statisticsSerializable.pongPlayer02LossGoalsRight =
            pongPlayer02LossGoalsRight;
        statisticsSerializable.pongPlayer02Losses =
            pongPlayer02Losses;

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

            pongPlayer01Displacement = 
                statisticsSerializable.pongPlayer01Displacement;
            pongPlayer01Hits = 
                statisticsSerializable.pongPlayer01Hits;
            pongPlayer01WinGoals = 
                statisticsSerializable.pongPlayer01WinGoals;
            pongPlayer01WinGoalsLeft = 
                statisticsSerializable.pongPlayer01WinGoalsLeft;
            pongPlayer01WinGoalsMiddle = 
                statisticsSerializable.pongPlayer01WinGoalsMiddle;
            pongPlayer01WinGoalsRight = 
                statisticsSerializable.pongPlayer01WinGoalsRight;
            pongPlayer01Wins = 
                statisticsSerializable.pongPlayer01Wins;
            pongPlayer01LossGoals = 
                statisticsSerializable.pongPlayer01LossGoals;
            pongPlayer01LossGoalsLeft = 
                statisticsSerializable.pongPlayer01LossGoalsLeft;
            pongPlayer01LossGoalsMiddle = 
                statisticsSerializable.pongPlayer01LossGoalsMiddle;
            pongPlayer01LossGoalsRight = 
                statisticsSerializable.pongPlayer01LossGoalsRight;
            pongPlayer01Losses = 
                statisticsSerializable.pongPlayer01Losses;
            pongPlayer02Displacement = 
                statisticsSerializable.pongPlayer02Displacement;
            pongPlayer02Hits = 
                statisticsSerializable.pongPlayer02Hits;
            pongPlayer02WinGoals = 
                statisticsSerializable.pongPlayer02WinGoals;
            pongPlayer02WinGoalsLeft = 
                statisticsSerializable.pongPlayer02WinGoalsLeft;
            pongPlayer02WinGoalsMiddle = 
                statisticsSerializable.pongPlayer02WinGoalsMiddle;
            pongPlayer02WinGoalsRight = 
                statisticsSerializable.pongPlayer02WinGoalsRight;
            pongPlayer02Wins = 
                statisticsSerializable.pongPlayer02Wins;
            pongPlayer02LossGoals = 
                statisticsSerializable.pongPlayer02LossGoals;
            pongPlayer02LossGoalsLeft = 
                statisticsSerializable.pongPlayer02LossGoalsLeft;
            pongPlayer02LossGoalsMiddle = 
                statisticsSerializable.pongPlayer02LossGoalsMiddle;
            pongPlayer02LossGoalsRight = 
                statisticsSerializable.pongPlayer02LossGoalsRight;
            pongPlayer02Losses = 
                statisticsSerializable.pongPlayer02Losses;
        }
    }

    [Serializable]
    private class StatisticsSerializable
    {
        // Player 01, independent values
        internal float pongPlayer01Displacement;

        internal int pongPlayer01Hits;

        internal int pongPlayer01WinGoals;

        internal int pongPlayer01WinGoalsLeft;

        internal int pongPlayer01WinGoalsMiddle;

        internal int pongPlayer01WinGoalsRight;

        internal int pongPlayer01Wins;

        internal int pongPlayer01LossGoals;

        internal int pongPlayer01LossGoalsLeft;

        internal int pongPlayer01LossGoalsMiddle;

        internal int pongPlayer01LossGoalsRight;

        internal int pongPlayer01Losses;

        // Player 01, dependent values

        // Player 02, independent values
        internal float pongPlayer02Displacement;

        internal int pongPlayer02Hits;

        internal int pongPlayer02WinGoals;

        internal int pongPlayer02WinGoalsLeft;

        internal int pongPlayer02WinGoalsMiddle;

        internal int pongPlayer02WinGoalsRight;

        internal int pongPlayer02Wins;

        internal int pongPlayer02LossGoals;

        internal int pongPlayer02LossGoalsLeft;

        internal int pongPlayer02LossGoalsMiddle;

        internal int pongPlayer02LossGoalsRight;

        internal int pongPlayer02Losses;

        // Player 02, dependent values
    }
}
