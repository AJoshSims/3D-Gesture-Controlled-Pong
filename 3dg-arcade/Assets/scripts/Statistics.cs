using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

internal class Statistics : MonoBehaviour
{
    public static Statistics statistics;

    private float[,] statisticsProfilesIndependent;

    internal const int statisticsIndependentNum = 12;

    internal readonly string[] statisticsIndependentNames =
        {"displacement", "hits",
        "win goals",
        "win goals left", "win goals middle", "win goals right",
        "wins",
        "loss goals",
        "loss goals left", "loss goals middle", "loss goals right",
        "losses"};

    // Independent values indices
    internal const int displacement = 0;

    internal const int hits = 1;

    internal const int winGoals = 2;

    internal const int winGoalsLeft = 3;

    internal const int winGoalsMiddle = 4;

    internal const int winGoalsRight = 5;

    internal const int wins = 6;

    internal const int lossGoals = 7;

    internal const int lossGoalsLeft = 8;

    internal const int lossGoalsMiddle = 9;

    internal const int lossGoalsRight = 10;

    internal const int losses = 11;

    private float[,] statisticsProfilesDependent;

    internal const int statisticsDependentNum = 33;

    internal readonly String[] statisticsDependentNames =
        {"displacement per hit",
        "displacement per win goal",
        "displacement per win goal left",
        "displacement per win goal middle",
        "displacement per win goal right",
        "displacement per win",
        "displacement per loss goal",
        "displacement per loss goal left",
        "displacement per loss goal middle",
        "displacement per loss goal right",
        "displacement per loss",
        "hits per win goal",
        "hits per win goal left",
        "hits per win goal middle",
        "hits per win goal right",
        "hits per win",
        "hits per loss goal",
        "hits per loss goal left",
        "hits per loss goal middle",
        "hits per loss goal right",
        "hits per loss",
        "win goals left per win goal",
        "win goals middle per win goal",
        "win goals right per win goal",
        "win goals left per win",
        "win goals middle per win",
        "win goals right per win",
        "loss goals left per loss goal",
        "loss goals middle per loss goal",
        "loss goals right per loss goal",
        "loss goals left per loss",
        "loss goals middle per loss",
        "loss goals right per loss"};

    // Dependent values indices
    internal const int displacementPerHit = 0;

    internal const int displacementPerWinGoal = 1;

    internal const int displacementPerWinGoalLeft = 2;

    internal const int displacementPerWinGoalMiddle = 3;

    internal const int displacementPerWinGoalRight = 4;

    internal const int displacementPerWin = 5;

    internal const int displacementPerLossGoal = 6;

    internal const int displacementPerLossGoalLeft = 7;

    internal const int displacementPerLossGoalMiddle = 8;

    internal const int displacementPerLossGoalRight = 9;

    internal const int displacementPerLoss = 10;

    internal const int hitsPerWinGoal = 11;

    internal const int hitsPerWinGoalLeft = 12;

    internal const int hitsPerWinGoalMiddle = 13;

    internal const int hitsPerWinGoalRight = 14;

    internal const int hitsPerWin = 15;

    internal const int hitsPerLossGoal = 16;

    internal const int hitsPerLossGoalLeft = 17;

    internal const int hitsPerLossGoalMiddle = 18;

    internal const int hitsPerLossGoalRight = 19;

    internal const int hitsPerLoss = 20;

    internal const int winGoalsLeftPerWinGoal = 21;

    internal const int winGoalsMiddlePerWinGoal = 22;

    internal const int winGoalsRightPerWinGoal = 23;

    internal const int winGoalsLeftPerWin = 24;

    internal const int winGoalsMiddlePerWin = 25;

    internal const int winGoalsRightPerWin = 26;

    internal const int lossGoalsLeftPerLossGoal = 27;

    internal const int lossGoalsMiddlePerLossGoal = 28;

    internal const int lossGoalsRightPerLossGoal = 29;

    internal const int lossGoalsLeftPerLoss = 30;

    internal const int lossGoalsMiddlePerLoss = 31;

    internal const int lossGoalsRightPerLoss = 32;

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

        statisticsProfilesDependent = 
            new float[Settings.profilesMax, statisticsDependentNum];
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

            statisticsProfilesIndependent = 
                statisticsSerializable.statisticsProfilesIndependent;
        }

        else
        {
            statisticsProfilesIndependent = 
                new float[Settings.profilesMax, statisticsIndependentNum];
        }
    }

    internal void Save()
    {
        FileStream statisticsFile = File.Open(
            Application.persistentDataPath + "/statistics.dat",
            FileMode.OpenOrCreate);

        StatisticsSerializable statisticsSerializable =
            new StatisticsSerializable();
        statisticsSerializable.statisticsProfilesIndependent =
            statisticsProfilesIndependent;
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.Serialize(statisticsFile, statisticsSerializable);

        statisticsFile.Close();
    }

    internal void UpdateStatisticIndependent(
        int profileIndex, int statisticIndex, float valueToUpdateBy)
    {
        if (profileIndex < Settings.profilesMax)
        {
            statisticsProfilesIndependent[profileIndex, statisticIndex] =
                statisticsProfilesIndependent[profileIndex, statisticIndex]
                + valueToUpdateBy;
        }
    }

    internal float[,] getStatisticsIndependent(int profile)
    {
        return statisticsProfilesIndependent;
    }

    internal float[,] getStatisticsDependent(int profile)
    {
        return statisticsProfilesDependent;
    }

    internal void CalculateStatisticsDependent(int profile)
    {
        statisticsProfilesDependent[profile, displacementPerHit] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, hits];
        statisticsProfilesDependent[profile, displacementPerWinGoal] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, winGoals];
        statisticsProfilesDependent[profile, displacementPerWinGoalLeft] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, winGoalsLeft];
        statisticsProfilesDependent[profile, displacementPerWinGoalMiddle] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, winGoalsMiddle];
        statisticsProfilesDependent[profile, displacementPerWinGoalRight] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, winGoalsRight];
        statisticsProfilesDependent[profile, displacementPerWin] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, wins];
        statisticsProfilesDependent[profile, displacementPerLossGoal] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, lossGoals];
        statisticsProfilesDependent[profile, displacementPerLossGoalLeft] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, lossGoalsLeft];
        statisticsProfilesDependent[profile, displacementPerLossGoalMiddle] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, lossGoalsMiddle];
        statisticsProfilesDependent[profile, displacementPerLossGoalRight] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, lossGoalsRight];
        statisticsProfilesDependent[profile, displacementPerLoss] =
            statisticsProfilesIndependent[profile, displacement]
            / statisticsProfilesIndependent[profile, losses];
        statisticsProfilesDependent[profile, hitsPerWinGoal] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, winGoals];
        statisticsProfilesDependent[profile, hitsPerWinGoalLeft] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, winGoalsLeft];
        statisticsProfilesDependent[profile, hitsPerWinGoalMiddle] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, winGoalsMiddle];
        statisticsProfilesDependent[profile, hitsPerWinGoalRight] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, winGoalsRight];
        statisticsProfilesDependent[profile, hitsPerWin] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, wins];
        statisticsProfilesDependent[profile, hitsPerLossGoal] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, lossGoals];
        statisticsProfilesDependent[profile, hitsPerLossGoalLeft] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, lossGoalsLeft];
        statisticsProfilesDependent[profile, hitsPerLossGoalMiddle] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, lossGoalsMiddle];
        statisticsProfilesDependent[profile, hitsPerLossGoalRight] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, lossGoalsRight];
        statisticsProfilesDependent[profile, hitsPerLoss] =
            statisticsProfilesIndependent[profile, hits]
            / statisticsProfilesIndependent[profile, losses];
        statisticsProfilesDependent[profile, winGoalsLeftPerWinGoal] =
            statisticsProfilesIndependent[profile, winGoalsLeft]
            / statisticsProfilesIndependent[profile, winGoals];
        statisticsProfilesDependent[profile, winGoalsMiddlePerWinGoal] =
            statisticsProfilesIndependent[profile, winGoalsMiddle]
            / statisticsProfilesIndependent[profile, winGoals];
        statisticsProfilesDependent[profile, winGoalsRightPerWinGoal] =
            statisticsProfilesIndependent[profile, winGoalsRight]
            / statisticsProfilesIndependent[profile, winGoals];
        statisticsProfilesDependent[profile, winGoalsLeftPerWin] =
            statisticsProfilesIndependent[profile, winGoalsLeft]
            / statisticsProfilesIndependent[profile, wins];
        statisticsProfilesDependent[profile, winGoalsMiddlePerWin] =
            statisticsProfilesIndependent[profile, winGoalsMiddle]
            / statisticsProfilesIndependent[profile, wins];
        statisticsProfilesDependent[profile, winGoalsRightPerWin] =
            statisticsProfilesIndependent[profile, winGoalsRight]
            / statisticsProfilesIndependent[profile, wins];
        statisticsProfilesDependent[profile, lossGoalsLeftPerLossGoal] =
            statisticsProfilesIndependent[profile, lossGoalsLeft]
            / statisticsProfilesIndependent[profile, lossGoals];
        statisticsProfilesDependent[profile, lossGoalsMiddlePerLossGoal] =
            statisticsProfilesIndependent[profile, lossGoalsMiddle]
            / statisticsProfilesIndependent[profile, lossGoals];
        statisticsProfilesDependent[profile, lossGoalsRightPerLossGoal] =
            statisticsProfilesIndependent[profile, lossGoalsRight]
            / statisticsProfilesIndependent[profile, lossGoals];
        statisticsProfilesDependent[profile, lossGoalsLeftPerLoss] =
            statisticsProfilesIndependent[profile, lossGoalsLeft]
            / statisticsProfilesIndependent[profile, losses];
        statisticsProfilesDependent[profile, lossGoalsMiddlePerLoss] =
            statisticsProfilesIndependent[profile, lossGoalsMiddle]
            / statisticsProfilesIndependent[profile, losses];
        statisticsProfilesDependent[profile, lossGoalsRightPerLoss] =
            statisticsProfilesIndependent[profile, lossGoalsRight]
            / statisticsProfilesIndependent[profile, lossGoals];
    }

    [Serializable]
    private class StatisticsSerializable
    {
        internal float[,] statisticsProfilesIndependent;
    }
}
