using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

internal class Statistics : MonoBehaviour
{
    public static Statistics statistics;

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
    internal float pongPlayer01DisplacementPerHit;

    internal float pongPlayer01DisplacementPerWinGoal;

    internal float pongPlayer01DisplacementPerWinGoalLeft;

    internal float pongPlayer01DisplacementPerWinGoalMiddle;

    internal float pongPlayer01DisplacementPerWinGoalRight;

    internal float pongPlayer01DisplacementPerWin;

    internal float pongPlayer01DisplacementPerLossGoal;

    internal float pongPlayer01DisplacementPerLossGoalLeft;

    internal float pongPlayer01DisplacementPerLossGoalMiddle;

    internal float pongPlayer01DisplacementPerLossGoalRight;

    internal float pongPlayer01DisplacementPerLoss;

    internal int pongPlayer01HitsPerWinGoal;

    internal int pongPlayer01HitsPerWinGoalLeft;

    internal int pongPlayer01HitsPerWinGoalMiddle;

    internal int pongPlayer01HitsPerWinGoalRight;

    internal int pongPlayer01HitsPerWin;

    internal int pongPlayer01HitsPerLossGoal;

    internal int pongPlayer01HitsPerLossGoalLeft;

    internal int pongPlayer01HitsPerLossGoalMiddle;

    internal int pongPlayer01HitsPerLossGoalRight;

    internal int pongPlayer01HitsPerLoss;

    internal int pongPlayer01WinGoalsLeftPerWinGoal;

    internal int pongPlayer01WinGoalsMiddlePerWinGoal;

    internal int pongPlayer01WinGoalsRightPerWinGoal;

    internal int pongPlayer01WinGoalsLeftPerWin;

    internal int pongPlayer01WinGoalsMiddlePerWin;

    internal int pongPlayer01WinGoalsRightPerWin;

    internal int pongPlayer01LossGoalsLeftPerLossGoal;

    internal int pongPlayer01LossGoalsMiddlePerLossGoal;

    internal int pongPlayer01LossGoalsRightPerLossGoal;

    internal int pongPlayer01LossGoalsLeftPerLoss;

    internal int pongPlayer01LossGoalsMiddlePerLoss;

    internal int pongPlayer01LossGoalsRightPerLoss;

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
    internal float pongPlayer02DisplacementPerHit;

    internal float pongPlayer02DisplacementPerWinGoal;

    internal float pongPlayer02DisplacementPerWinGoalLeft;

    internal float pongPlayer02DisplacementPerWinGoalMiddle;

    internal float pongPlayer02DisplacementPerWinGoalRight;

    internal float pongPlayer02DisplacementPerWin;

    internal float pongPlayer02DisplacementPerLossGoal;

    internal float pongPlayer02DisplacementPerLossGoalLeft;

    internal float pongPlayer02DisplacementPerLossGoalMiddle;

    internal float pongPlayer02DisplacementPerLossGoalRight;

    internal float pongPlayer02DisplacementPerLoss;

    internal int pongPlayer02HitsPerWinGoal;

    internal int pongPlayer02HitsPerWinGoalLeft;

    internal int pongPlayer02HitsPerWinGoalMiddle;

    internal int pongPlayer02HitsPerWinGoalRight;

    internal int pongPlayer02HitsPerWin;

    internal int pongPlayer02HitsPerLossGoal;

    internal int pongPlayer02HitsPerLossGoalLeft;

    internal int pongPlayer02HitsPerLossGoalMiddle;

    internal int pongPlayer02HitsPerLossGoalRight;

    internal int pongPlayer02HitsPerLoss;

    internal int pongPlayer02WinGoalsLeftPerWinGoal;

    internal int pongPlayer02WinGoalsMiddlePerWinGoal;

    internal int pongPlayer02WinGoalsRightPerWinGoal;

    internal int pongPlayer02WinGoalsLeftPerWin;

    internal int pongPlayer02WinGoalsMiddlePerWin;

    internal int pongPlayer02WinGoalsRightPerWin;

    internal int pongPlayer02LossGoalsLeftPerLossGoal;

    internal int pongPlayer02LossGoalsMiddlePerLossGoal;

    internal int pongPlayer02LossGoalsRightPerLossGoal;

    internal int pongPlayer02LossGoalsLeftPerLoss;

    internal int pongPlayer02LossGoalsMiddlePerLoss;

    internal int pongPlayer02LossGoalsRightPerLoss;

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

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/statistics.dat"))
        {
            FileStream statisticsFile = File.Open(
                Application.persistentDataPath + "/statistics.dat",
                FileMode.Open);

            BinaryFormatter deserializer = new BinaryFormatter();

            StatisticsSerializable statisticsSerializable =
                (StatisticsSerializable)deserializer.Deserialize(
                statisticsFile);
            statisticsFile.Close();

            // Player 01, independent values
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

            // Player 01, dependent values
            pongPlayer01DisplacementPerHit =
                statisticsSerializable.pongPlayer01DisplacementPerHit;
            pongPlayer01DisplacementPerWinGoal =
                statisticsSerializable.pongPlayer01DisplacementPerWinGoal;
            pongPlayer01DisplacementPerWinGoalLeft =
                statisticsSerializable.pongPlayer01DisplacementPerWinGoalLeft;
            pongPlayer01DisplacementPerWinGoalMiddle =
                statisticsSerializable.pongPlayer01DisplacementPerWinGoalMiddle;
            pongPlayer01DisplacementPerWinGoalRight =
                statisticsSerializable.pongPlayer01DisplacementPerWinGoalRight;
            pongPlayer01DisplacementPerWin =
                statisticsSerializable.pongPlayer01DisplacementPerWin;
            pongPlayer01DisplacementPerLossGoal =
                statisticsSerializable.pongPlayer01DisplacementPerLossGoal;
            pongPlayer01DisplacementPerLossGoalLeft =
                statisticsSerializable.pongPlayer01DisplacementPerLossGoalLeft;
            pongPlayer01DisplacementPerLossGoalMiddle =
                statisticsSerializable.pongPlayer01DisplacementPerLossGoalMiddle;
            pongPlayer01DisplacementPerLossGoalRight =
                statisticsSerializable.pongPlayer01DisplacementPerLossGoalRight;
            pongPlayer01DisplacementPerLoss =
                statisticsSerializable.pongPlayer01DisplacementPerLoss;
            pongPlayer01HitsPerWinGoal =
                statisticsSerializable.pongPlayer01HitsPerWinGoal;
            pongPlayer01HitsPerWinGoalLeft =
                statisticsSerializable.pongPlayer01HitsPerWinGoalLeft;
            pongPlayer01HitsPerWinGoalMiddle =
                statisticsSerializable.pongPlayer01HitsPerWinGoalMiddle;
            pongPlayer01HitsPerWinGoalRight =
                statisticsSerializable.pongPlayer01HitsPerWinGoalRight;
            pongPlayer01HitsPerWin =
                statisticsSerializable.pongPlayer01HitsPerWin;
            pongPlayer01HitsPerLossGoal =
                statisticsSerializable.pongPlayer01HitsPerLossGoal;
            pongPlayer01HitsPerLossGoalLeft =
                statisticsSerializable.pongPlayer01HitsPerLossGoalLeft;
            pongPlayer01HitsPerLossGoalMiddle =
                statisticsSerializable.pongPlayer01HitsPerLossGoalMiddle;
            pongPlayer01HitsPerLossGoalRight =
                statisticsSerializable.pongPlayer01HitsPerLossGoalRight;
            pongPlayer01HitsPerLoss =
                statisticsSerializable.pongPlayer01HitsPerLoss;
            pongPlayer01WinGoalsLeftPerWinGoal =
                statisticsSerializable.pongPlayer01WinGoalsLeftPerWinGoal;
            pongPlayer01WinGoalsMiddlePerWinGoal =
                statisticsSerializable.pongPlayer01WinGoalsMiddlePerWinGoal;
            pongPlayer01WinGoalsRightPerWinGoal =
                statisticsSerializable.pongPlayer01WinGoalsRightPerWinGoal;
            pongPlayer01WinGoalsLeftPerWin =
                statisticsSerializable.pongPlayer01WinGoalsLeftPerWin;
            pongPlayer01WinGoalsMiddlePerWin =
                statisticsSerializable.pongPlayer01WinGoalsMiddlePerWin;
            pongPlayer01WinGoalsRightPerWin =
                statisticsSerializable.pongPlayer01WinGoalsRightPerWin;
            pongPlayer01LossGoalsLeftPerLossGoal =
                statisticsSerializable.pongPlayer01LossGoalsLeftPerLossGoal;
            pongPlayer01LossGoalsMiddlePerLossGoal =
                statisticsSerializable.pongPlayer01LossGoalsMiddlePerLossGoal;
            pongPlayer01LossGoalsRightPerLossGoal =
                statisticsSerializable.pongPlayer01LossGoalsRightPerLossGoal;
            pongPlayer01LossGoalsLeftPerLoss =
                statisticsSerializable.pongPlayer01LossGoalsLeftPerLoss;
            pongPlayer01LossGoalsMiddlePerLoss =
                statisticsSerializable.pongPlayer01LossGoalsMiddlePerLoss;
            pongPlayer01LossGoalsRightPerLoss =
                statisticsSerializable.pongPlayer01LossGoalsRightPerLoss;

            // Player 02, independent values
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

            // Player 02, dependent values
            pongPlayer02DisplacementPerHit =
                statisticsSerializable.pongPlayer02DisplacementPerHit;
            pongPlayer02DisplacementPerWinGoal =
                statisticsSerializable.pongPlayer02DisplacementPerWinGoal;
            pongPlayer02DisplacementPerWinGoalLeft =
                statisticsSerializable.pongPlayer02DisplacementPerWinGoalLeft;
            pongPlayer02DisplacementPerWinGoalMiddle =
                statisticsSerializable.pongPlayer02DisplacementPerWinGoalMiddle;
            pongPlayer02DisplacementPerWinGoalRight =
                statisticsSerializable.pongPlayer02DisplacementPerWinGoalRight;
            pongPlayer02DisplacementPerWin =
                statisticsSerializable.pongPlayer02DisplacementPerWin;
            pongPlayer02DisplacementPerLossGoal =
                statisticsSerializable.pongPlayer02DisplacementPerLossGoal;
            pongPlayer02DisplacementPerLossGoalLeft =
                statisticsSerializable.pongPlayer02DisplacementPerLossGoalLeft;
            pongPlayer02DisplacementPerLossGoalMiddle =
                statisticsSerializable.pongPlayer02DisplacementPerLossGoalMiddle;
            pongPlayer02DisplacementPerLossGoalRight =
                statisticsSerializable.pongPlayer02DisplacementPerLossGoalRight;
            pongPlayer02DisplacementPerLoss =
                statisticsSerializable.pongPlayer02DisplacementPerLoss;
            pongPlayer02HitsPerWinGoal =
                statisticsSerializable.pongPlayer02HitsPerWinGoal;
            pongPlayer02HitsPerWinGoalLeft =
                statisticsSerializable.pongPlayer02HitsPerWinGoalLeft;
            pongPlayer02HitsPerWinGoalMiddle =
                statisticsSerializable.pongPlayer02HitsPerWinGoalMiddle;
            pongPlayer02HitsPerWinGoalRight =
                statisticsSerializable.pongPlayer02HitsPerWinGoalRight;
            pongPlayer02HitsPerWin =
                statisticsSerializable.pongPlayer02HitsPerWin;
            pongPlayer02HitsPerLossGoal =
                statisticsSerializable.pongPlayer02HitsPerLossGoal;
            pongPlayer02HitsPerLossGoalLeft =
                statisticsSerializable.pongPlayer02HitsPerLossGoalLeft;
            pongPlayer02HitsPerLossGoalMiddle =
                statisticsSerializable.pongPlayer02HitsPerLossGoalMiddle;
            pongPlayer02HitsPerLossGoalRight =
                statisticsSerializable.pongPlayer02HitsPerLossGoalRight;
            pongPlayer02HitsPerLoss =
                statisticsSerializable.pongPlayer02HitsPerLoss;
            pongPlayer02WinGoalsLeftPerWinGoal =
                statisticsSerializable.pongPlayer02WinGoalsLeftPerWinGoal;
            pongPlayer02WinGoalsMiddlePerWinGoal =
                statisticsSerializable.pongPlayer02WinGoalsMiddlePerWinGoal;
            pongPlayer02WinGoalsRightPerWinGoal =
                statisticsSerializable.pongPlayer02WinGoalsRightPerWinGoal;
            pongPlayer02WinGoalsLeftPerWin =
                statisticsSerializable.pongPlayer02WinGoalsLeftPerWin;
            pongPlayer02WinGoalsMiddlePerWin =
                statisticsSerializable.pongPlayer02WinGoalsMiddlePerWin;
            pongPlayer02WinGoalsRightPerWin =
                statisticsSerializable.pongPlayer02WinGoalsRightPerWin;
            pongPlayer02LossGoalsLeftPerLossGoal =
                statisticsSerializable.pongPlayer02LossGoalsLeftPerLossGoal;
            pongPlayer02LossGoalsMiddlePerLossGoal =
                statisticsSerializable.pongPlayer02LossGoalsMiddlePerLossGoal;
            pongPlayer02LossGoalsRightPerLossGoal =
                statisticsSerializable.pongPlayer02LossGoalsRightPerLossGoal;
            pongPlayer02LossGoalsLeftPerLoss =
                statisticsSerializable.pongPlayer02LossGoalsLeftPerLoss;
            pongPlayer02LossGoalsMiddlePerLoss =
                statisticsSerializable.pongPlayer02LossGoalsMiddlePerLoss;
            pongPlayer02LossGoalsRightPerLoss =
                statisticsSerializable.pongPlayer02LossGoalsRightPerLoss;
        }
    }

    private void Calculate()
    {
        // Player 01, dependent values
        pongPlayer01DisplacementPerHit =
            pongPlayer01Displacement / pongPlayer01Hits;
        pongPlayer01DisplacementPerWinGoal =
            pongPlayer01Displacement / pongPlayer01WinGoals;
        pongPlayer01DisplacementPerWinGoalLeft =
            pongPlayer01Displacement / pongPlayer01WinGoalsLeft;
        pongPlayer01DisplacementPerWinGoalMiddle =
            pongPlayer01Displacement / pongPlayer01WinGoalsMiddle;
        pongPlayer01DisplacementPerWinGoalRight =
            pongPlayer01Displacement / pongPlayer01WinGoalsRight;
        pongPlayer01DisplacementPerWin =
            pongPlayer01Displacement / pongPlayer01Wins;
        pongPlayer01DisplacementPerLossGoal =
            pongPlayer01Displacement / pongPlayer01LossGoals;
        pongPlayer01DisplacementPerLossGoalLeft =
            pongPlayer01Displacement / pongPlayer01LossGoalsLeft;
        pongPlayer01DisplacementPerLossGoalMiddle =
            pongPlayer01Displacement / pongPlayer01LossGoalsMiddle;
        pongPlayer01DisplacementPerLossGoalRight =
            pongPlayer01Displacement / pongPlayer01LossGoalsRight;
        pongPlayer01DisplacementPerLoss =
            pongPlayer01Displacement / pongPlayer01Losses;
        pongPlayer01HitsPerWinGoal =
            pongPlayer01Hits / pongPlayer01WinGoals;
        pongPlayer01HitsPerWinGoalLeft =
            pongPlayer01Hits / pongPlayer01WinGoalsLeft;
        pongPlayer01HitsPerWinGoalMiddle =
            pongPlayer01Hits / pongPlayer01WinGoalsMiddle;
        pongPlayer01HitsPerWinGoalRight =
            pongPlayer01Hits / pongPlayer01WinGoalsRight;
        pongPlayer01HitsPerWin =
            pongPlayer02Hits / pongPlayer01Wins;
        pongPlayer01HitsPerLossGoal =
            pongPlayer01Hits / pongPlayer01LossGoals;
        pongPlayer01HitsPerLossGoalLeft =
            pongPlayer01Hits / pongPlayer01LossGoalsLeft;
        pongPlayer01HitsPerLossGoalMiddle =
            pongPlayer01Hits / pongPlayer01LossGoalsMiddle;
        pongPlayer01HitsPerLossGoalRight =
            pongPlayer01Hits / pongPlayer01LossGoalsRight;
        pongPlayer01HitsPerLoss =
            pongPlayer02Hits / pongPlayer01Losses;
        pongPlayer01WinGoalsLeftPerWinGoal =
            pongPlayer01WinGoalsLeft / pongPlayer01WinGoals;
        pongPlayer01WinGoalsMiddlePerWinGoal =
            pongPlayer01WinGoalsMiddle / pongPlayer01WinGoals;
        pongPlayer01WinGoalsRightPerWinGoal =
            pongPlayer01WinGoalsRight / pongPlayer01WinGoals;
        pongPlayer01WinGoalsLeftPerWin =
            pongPlayer01WinGoalsLeft / pongPlayer01Wins;
        pongPlayer01WinGoalsMiddlePerWin =
            pongPlayer01WinGoalsMiddle / pongPlayer01Wins;
        pongPlayer01WinGoalsRightPerWin =
            pongPlayer01WinGoalsRight / pongPlayer01Wins;
        pongPlayer01LossGoalsLeftPerLossGoal =
            pongPlayer01LossGoalsLeft / pongPlayer01LossGoals;
        pongPlayer01LossGoalsMiddlePerLossGoal =
            pongPlayer01LossGoalsMiddle / pongPlayer01LossGoals;
        pongPlayer01LossGoalsRightPerLossGoal =
            pongPlayer01LossGoalsRight / pongPlayer01LossGoals;
        pongPlayer01LossGoalsLeftPerLoss =
            pongPlayer01LossGoalsLeft / pongPlayer01Losses;
        pongPlayer01LossGoalsMiddlePerLoss =
            pongPlayer01LossGoalsMiddle / pongPlayer01Losses;
        pongPlayer01LossGoalsRightPerLoss =
            pongPlayer01LossGoalsRight / pongPlayer01Losses;

        // Player 02, dependent values
        pongPlayer02DisplacementPerHit =
            pongPlayer02Displacement / pongPlayer02Hits;
        pongPlayer02DisplacementPerWinGoal =
            pongPlayer02Displacement / pongPlayer02WinGoals;
        pongPlayer02DisplacementPerWinGoalLeft =
            pongPlayer02Displacement / pongPlayer02WinGoalsLeft;
        pongPlayer02DisplacementPerWinGoalMiddle =
            pongPlayer02Displacement / pongPlayer02WinGoalsMiddle;
        pongPlayer02DisplacementPerWinGoalRight =
            pongPlayer02Displacement / pongPlayer02WinGoalsRight;
        pongPlayer02DisplacementPerWin =
            pongPlayer02Displacement / pongPlayer02Wins;
        pongPlayer02DisplacementPerLossGoal =
            pongPlayer02Displacement / pongPlayer02LossGoals;
        pongPlayer02DisplacementPerLossGoalLeft =
            pongPlayer02Displacement / pongPlayer02LossGoalsLeft;
        pongPlayer02DisplacementPerLossGoalMiddle =
            pongPlayer02Displacement / pongPlayer02LossGoalsMiddle;
        pongPlayer02DisplacementPerLossGoalRight =
            pongPlayer02Displacement / pongPlayer02LossGoalsRight;
        pongPlayer02DisplacementPerLoss =
            pongPlayer02Displacement / pongPlayer02Losses;
        pongPlayer02HitsPerWinGoal =
            pongPlayer02Hits / pongPlayer02WinGoals;
        pongPlayer02HitsPerWinGoalLeft =
            pongPlayer02Hits / pongPlayer02WinGoalsLeft;
        pongPlayer02HitsPerWinGoalMiddle =
            pongPlayer02Hits / pongPlayer02WinGoalsMiddle;
        pongPlayer02HitsPerWinGoalRight =
            pongPlayer02Hits / pongPlayer02WinGoalsRight;
        pongPlayer02HitsPerWin =
            pongPlayer02Hits / pongPlayer02Wins;
        pongPlayer02HitsPerLossGoal =
            pongPlayer02Hits / pongPlayer02LossGoals;
        pongPlayer02HitsPerLossGoalLeft =
            pongPlayer02Hits / pongPlayer02LossGoalsLeft;
        pongPlayer02HitsPerLossGoalMiddle =
            pongPlayer02Hits / pongPlayer02LossGoalsMiddle;
        pongPlayer02HitsPerLossGoalRight =
            pongPlayer02Hits / pongPlayer02LossGoalsRight;
        pongPlayer02HitsPerLoss =
            pongPlayer02Hits / pongPlayer02Losses;
        pongPlayer02WinGoalsLeftPerWinGoal =
            pongPlayer02WinGoalsLeft / pongPlayer02WinGoals;
        pongPlayer02WinGoalsMiddlePerWinGoal =
            pongPlayer02WinGoalsMiddle / pongPlayer02WinGoals;
        pongPlayer02WinGoalsRightPerWinGoal =
            pongPlayer02WinGoalsRight / pongPlayer02WinGoals;
        pongPlayer02WinGoalsLeftPerWin =
            pongPlayer02WinGoalsLeft / pongPlayer02Wins;
        pongPlayer02WinGoalsMiddlePerWin =
            pongPlayer02WinGoalsMiddle / pongPlayer02Wins;
        pongPlayer02WinGoalsRightPerWin =
            pongPlayer02WinGoalsRight / pongPlayer02Wins;
        pongPlayer02LossGoalsLeftPerLossGoal =
            pongPlayer02LossGoalsLeft / pongPlayer02LossGoals;
        pongPlayer02LossGoalsMiddlePerLossGoal =
            pongPlayer02LossGoalsMiddle / pongPlayer02LossGoals;
        pongPlayer02LossGoalsRightPerLossGoal =
            pongPlayer02LossGoalsRight / pongPlayer02LossGoals;
        pongPlayer02LossGoalsLeftPerLoss =
            pongPlayer02LossGoalsLeft / pongPlayer02Losses;
        pongPlayer02LossGoalsMiddlePerLoss =
            pongPlayer02LossGoalsMiddle / pongPlayer02Losses;
        pongPlayer02LossGoalsRightPerLoss =
            pongPlayer02LossGoalsRight / pongPlayer02Losses;
    }

    internal void Save()
    {
        Calculate();

        FileStream statisticsFile = File.Open(
            Application.persistentDataPath + "/statistics.dat", 
            FileMode.OpenOrCreate);

        StatisticsSerializable statisticsSerializable = 
            new StatisticsSerializable();

        // Player 01, independent values
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

        // Player 01, dependent values
        statisticsSerializable.pongPlayer01DisplacementPerHit =
            pongPlayer01DisplacementPerHit;
        statisticsSerializable.pongPlayer01DisplacementPerWinGoal =
            pongPlayer01DisplacementPerWinGoal;
        statisticsSerializable.pongPlayer01DisplacementPerWinGoalLeft =
            pongPlayer01DisplacementPerWinGoalLeft;
        statisticsSerializable.pongPlayer01DisplacementPerWinGoalMiddle =
            pongPlayer01DisplacementPerWinGoalMiddle;
        statisticsSerializable.pongPlayer01DisplacementPerWinGoalRight =
            pongPlayer01DisplacementPerWinGoalRight;
        statisticsSerializable.pongPlayer01DisplacementPerWin =
            pongPlayer01DisplacementPerWin;
        statisticsSerializable.pongPlayer01DisplacementPerLossGoal =
            pongPlayer01DisplacementPerLossGoal;
        statisticsSerializable.pongPlayer01DisplacementPerLossGoalLeft =
            pongPlayer01DisplacementPerLossGoalLeft;
        statisticsSerializable.pongPlayer01DisplacementPerLossGoalMiddle =
            pongPlayer01DisplacementPerLossGoalMiddle;
        statisticsSerializable.pongPlayer01DisplacementPerLossGoalRight =
            pongPlayer01DisplacementPerLossGoalRight;
        statisticsSerializable.pongPlayer01DisplacementPerLoss =
            pongPlayer01DisplacementPerLoss;
        statisticsSerializable.pongPlayer01HitsPerWinGoal =
            pongPlayer01HitsPerWinGoal;
        statisticsSerializable.pongPlayer01HitsPerWinGoalLeft =
            pongPlayer01HitsPerWinGoalLeft;
        statisticsSerializable.pongPlayer01HitsPerWinGoalMiddle =
            pongPlayer01HitsPerWinGoalMiddle;
        statisticsSerializable.pongPlayer01HitsPerWinGoalRight =
            pongPlayer01HitsPerWinGoalRight;
        statisticsSerializable.pongPlayer01HitsPerWin =
            pongPlayer01HitsPerWin;
        statisticsSerializable.pongPlayer01HitsPerLossGoal =
            pongPlayer01HitsPerLossGoal;
        statisticsSerializable.pongPlayer01HitsPerLossGoalLeft =
            pongPlayer01HitsPerLossGoalLeft;
        statisticsSerializable.pongPlayer01HitsPerLossGoalMiddle =
            pongPlayer01HitsPerLossGoalMiddle;
        statisticsSerializable.pongPlayer01HitsPerLossGoalRight =
            pongPlayer01HitsPerLossGoalRight;
        statisticsSerializable.pongPlayer01HitsPerLoss =
            pongPlayer01HitsPerLoss;
        statisticsSerializable.pongPlayer01WinGoalsLeftPerWinGoal =
            pongPlayer01WinGoalsLeftPerWinGoal;
        statisticsSerializable.pongPlayer01WinGoalsMiddlePerWinGoal =
            pongPlayer01WinGoalsMiddlePerWinGoal;
        statisticsSerializable.pongPlayer01WinGoalsRightPerWinGoal =
            pongPlayer01WinGoalsRightPerWinGoal;
        statisticsSerializable.pongPlayer01WinGoalsLeftPerWin =
            pongPlayer01WinGoalsLeftPerWin;
        statisticsSerializable.pongPlayer01WinGoalsMiddlePerWin =
            pongPlayer01WinGoalsMiddlePerWin;
        statisticsSerializable.pongPlayer01WinGoalsRightPerWin =
            pongPlayer01WinGoalsRightPerWin;
        statisticsSerializable.pongPlayer01LossGoalsLeftPerLossGoal =
            pongPlayer01LossGoalsLeftPerLossGoal;
        statisticsSerializable.pongPlayer01LossGoalsMiddlePerLossGoal =
            pongPlayer01LossGoalsMiddlePerLossGoal;
        statisticsSerializable.pongPlayer01LossGoalsRightPerLossGoal =
            pongPlayer01LossGoalsRightPerLossGoal;
        statisticsSerializable.pongPlayer01LossGoalsLeftPerLoss =
            pongPlayer01LossGoalsLeftPerLoss;
        statisticsSerializable.pongPlayer01LossGoalsMiddlePerLoss =
            pongPlayer01LossGoalsMiddlePerLoss;
        statisticsSerializable.pongPlayer01LossGoalsRightPerLoss =
            pongPlayer01LossGoalsRightPerLoss;

        // Player 02, independent values
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

        // Player 02, dependent values
        statisticsSerializable.pongPlayer02DisplacementPerHit =
            pongPlayer02DisplacementPerHit;
        statisticsSerializable.pongPlayer02DisplacementPerWinGoal =
            pongPlayer02DisplacementPerWinGoal;
        statisticsSerializable.pongPlayer02DisplacementPerWinGoalLeft =
            pongPlayer02DisplacementPerWinGoalLeft;
        statisticsSerializable.pongPlayer02DisplacementPerWinGoalMiddle =
            pongPlayer02DisplacementPerWinGoalMiddle;
        statisticsSerializable.pongPlayer02DisplacementPerWinGoalRight =
            pongPlayer02DisplacementPerWinGoalRight;
        statisticsSerializable.pongPlayer02DisplacementPerWin =
            pongPlayer02DisplacementPerWin;
        statisticsSerializable.pongPlayer02DisplacementPerLossGoal =
            pongPlayer02DisplacementPerLossGoal;
        statisticsSerializable.pongPlayer02DisplacementPerLossGoalLeft =
            pongPlayer02DisplacementPerLossGoalLeft;
        statisticsSerializable.pongPlayer02DisplacementPerLossGoalMiddle =
            pongPlayer02DisplacementPerLossGoalMiddle;
        statisticsSerializable.pongPlayer02DisplacementPerLossGoalRight =
            pongPlayer02DisplacementPerLossGoalRight;
        statisticsSerializable.pongPlayer02DisplacementPerLoss =
            pongPlayer02DisplacementPerLoss;
        statisticsSerializable.pongPlayer02HitsPerWinGoal =
            pongPlayer02HitsPerWinGoal;
        statisticsSerializable.pongPlayer02HitsPerWinGoalLeft =
            pongPlayer02HitsPerWinGoalLeft;
        statisticsSerializable.pongPlayer02HitsPerWinGoalMiddle =
            pongPlayer02HitsPerWinGoalMiddle;
        statisticsSerializable.pongPlayer02HitsPerWinGoalRight =
            pongPlayer02HitsPerWinGoalRight;
        statisticsSerializable.pongPlayer02HitsPerWin =
            pongPlayer02HitsPerWin;
        statisticsSerializable.pongPlayer02HitsPerLossGoal =
            pongPlayer02HitsPerLossGoal;
        statisticsSerializable.pongPlayer02HitsPerLossGoalLeft =
            pongPlayer02HitsPerLossGoalLeft;
        statisticsSerializable.pongPlayer02HitsPerLossGoalMiddle =
            pongPlayer02HitsPerLossGoalMiddle;
        statisticsSerializable.pongPlayer02HitsPerLossGoalRight =
            pongPlayer02HitsPerLossGoalRight;
        statisticsSerializable.pongPlayer02HitsPerLoss =
            pongPlayer02HitsPerLoss;
        statisticsSerializable.pongPlayer02WinGoalsLeftPerWinGoal =
            pongPlayer02WinGoalsLeftPerWinGoal;
        statisticsSerializable.pongPlayer02WinGoalsMiddlePerWinGoal =
            pongPlayer02WinGoalsMiddlePerWinGoal;
        statisticsSerializable.pongPlayer02WinGoalsRightPerWinGoal =
            pongPlayer02WinGoalsRightPerWinGoal;
        statisticsSerializable.pongPlayer02WinGoalsLeftPerWin =
            pongPlayer02WinGoalsLeftPerWin;
        statisticsSerializable.pongPlayer02WinGoalsMiddlePerWin =
            pongPlayer02WinGoalsMiddlePerWin;
        statisticsSerializable.pongPlayer02WinGoalsRightPerWin =
            pongPlayer02WinGoalsRightPerWin;
        statisticsSerializable.pongPlayer02LossGoalsLeftPerLossGoal =
            pongPlayer02LossGoalsLeftPerLossGoal;
        statisticsSerializable.pongPlayer02LossGoalsMiddlePerLossGoal =
            pongPlayer02LossGoalsMiddlePerLossGoal;
        statisticsSerializable.pongPlayer02LossGoalsRightPerLossGoal =
            pongPlayer02LossGoalsRightPerLossGoal;
        statisticsSerializable.pongPlayer02LossGoalsLeftPerLoss =
            pongPlayer02LossGoalsLeftPerLoss;
        statisticsSerializable.pongPlayer02LossGoalsMiddlePerLoss =
            pongPlayer02LossGoalsMiddlePerLoss;
        statisticsSerializable.pongPlayer02LossGoalsRightPerLoss =
            pongPlayer02LossGoalsRightPerLoss;

        SaveToHumanReadableFile(statisticsSerializable);

        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(statisticsFile, statisticsSerializable);

        statisticsFile.Close();       
    }

    private void SaveToHumanReadableFile(
        StatisticsSerializable statisticsSerializable)
    {
        string statisticsJson = JsonUtility.ToJson(statisticsSerializable);

        File.WriteAllText(
            Application.persistentDataPath + "/statisticsJson.json",
            statisticsJson);
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
        internal float pongPlayer01DisplacementPerHit;

        internal float pongPlayer01DisplacementPerWinGoal;

        internal float pongPlayer01DisplacementPerWinGoalLeft;

        internal float pongPlayer01DisplacementPerWinGoalMiddle;

        internal float pongPlayer01DisplacementPerWinGoalRight;

        internal float pongPlayer01DisplacementPerWin;

        internal float pongPlayer01DisplacementPerLossGoal;

        internal float pongPlayer01DisplacementPerLossGoalLeft;

        internal float pongPlayer01DisplacementPerLossGoalMiddle;

        internal float pongPlayer01DisplacementPerLossGoalRight;

        internal float pongPlayer01DisplacementPerLoss;

        internal int pongPlayer01HitsPerWinGoal;

        internal int pongPlayer01HitsPerWinGoalLeft;

        internal int pongPlayer01HitsPerWinGoalMiddle;

        internal int pongPlayer01HitsPerWinGoalRight;

        internal int pongPlayer01HitsPerWin;

        internal int pongPlayer01HitsPerLossGoal;

        internal int pongPlayer01HitsPerLossGoalLeft;

        internal int pongPlayer01HitsPerLossGoalMiddle;

        internal int pongPlayer01HitsPerLossGoalRight;

        internal int pongPlayer01HitsPerLoss;

        internal int pongPlayer01WinGoalsLeftPerWinGoal;

        internal int pongPlayer01WinGoalsMiddlePerWinGoal;

        internal int pongPlayer01WinGoalsRightPerWinGoal;

        internal int pongPlayer01WinGoalsLeftPerWin;

        internal int pongPlayer01WinGoalsMiddlePerWin;

        internal int pongPlayer01WinGoalsRightPerWin;

        internal int pongPlayer01LossGoalsLeftPerLossGoal;

        internal int pongPlayer01LossGoalsMiddlePerLossGoal;

        internal int pongPlayer01LossGoalsRightPerLossGoal;

        internal int pongPlayer01LossGoalsLeftPerLoss;

        internal int pongPlayer01LossGoalsMiddlePerLoss;

        internal int pongPlayer01LossGoalsRightPerLoss;

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
        internal float pongPlayer02DisplacementPerHit;

        internal float pongPlayer02DisplacementPerWinGoal;

        internal float pongPlayer02DisplacementPerWinGoalLeft;

        internal float pongPlayer02DisplacementPerWinGoalMiddle;

        internal float pongPlayer02DisplacementPerWinGoalRight;

        internal float pongPlayer02DisplacementPerWin;

        internal float pongPlayer02DisplacementPerLossGoal;

        internal float pongPlayer02DisplacementPerLossGoalLeft;

        internal float pongPlayer02DisplacementPerLossGoalMiddle;

        internal float pongPlayer02DisplacementPerLossGoalRight;

        internal float pongPlayer02DisplacementPerLoss;

        internal int pongPlayer02HitsPerWinGoal;

        internal int pongPlayer02HitsPerWinGoalLeft;

        internal int pongPlayer02HitsPerWinGoalMiddle;

        internal int pongPlayer02HitsPerWinGoalRight;

        internal int pongPlayer02HitsPerWin;

        internal int pongPlayer02HitsPerLossGoal;

        internal int pongPlayer02HitsPerLossGoalLeft;

        internal int pongPlayer02HitsPerLossGoalMiddle;

        internal int pongPlayer02HitsPerLossGoalRight;

        internal int pongPlayer02HitsPerLoss;

        internal int pongPlayer02WinGoalsLeftPerWinGoal;

        internal int pongPlayer02WinGoalsMiddlePerWinGoal;

        internal int pongPlayer02WinGoalsRightPerWinGoal;

        internal int pongPlayer02WinGoalsLeftPerWin;

        internal int pongPlayer02WinGoalsMiddlePerWin;

        internal int pongPlayer02WinGoalsRightPerWin;

        internal int pongPlayer02LossGoalsLeftPerLossGoal;

        internal int pongPlayer02LossGoalsMiddlePerLossGoal;

        internal int pongPlayer02LossGoalsRightPerLossGoal;

        internal int pongPlayer02LossGoalsLeftPerLoss;

        internal int pongPlayer02LossGoalsMiddlePerLoss;

        internal int pongPlayer02LossGoalsRightPerLoss;
    }
}
