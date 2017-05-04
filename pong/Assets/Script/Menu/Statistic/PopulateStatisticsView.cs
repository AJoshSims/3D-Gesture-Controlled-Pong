using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopulateStatisticsView : MonoBehaviour
{
    private Dropdown thisDropdown;

    public GameObject statisticsViewContent;

    public GameObject statisticText;

    private Text[] statisticTexts;

    private void Start()
    {
        thisDropdown = gameObject.GetComponent<Dropdown>();
        string profileToPlace = null;
        for (
            int i = 0;
            i < Settings.profilesMax;
            ++i)
        {
            profileToPlace = Settings.settings.getProfileName(i);
            if (profileToPlace.Equals("<create profile>"))
            {
                profileToPlace = "unavailable";
            }

            thisDropdown.options[i] = new Dropdown.OptionData(profileToPlace);
        }
        thisDropdown.value = 0;
        thisDropdown.captionText.text = thisDropdown.options[0].text;

        Statistics.statistics.CalculateStatisticsDependent(0);

        GameObject statistic = null;
        float changeBy = 0;
        statisticTexts = 
            new Text[
            Statistics.statisticsIndependentNum + 
            Statistics.statisticsDependentNum];
        Text statisticTextText = null;
        int statisticTextsIndex = 0;

        for (
            int statisticIndex = 0;
            statisticIndex < Statistics.statisticsIndependentNum;
            ++statisticIndex)
        {
            statistic = Instantiate(statisticText);
            statistic.transform.SetParent(
                statisticsViewContent.transform, false);
            statistic.transform.position =
                new Vector3(
                statistic.transform.position.x,
                statistic.transform.position.y - changeBy,
                statistic.transform.position.z);
            changeBy = changeBy + 30;

            statisticTextText = statistic.GetComponent<Text>();
            statisticTexts[statisticTextsIndex] = statisticTextText;
            statisticTextText.text =
                Statistics.statistics.
                statisticsIndependentNames[statisticIndex] + ": " + 
                Statistics.statistics.getStatisticIndependent(
                0, statisticIndex);

            ++statisticTextsIndex;
        }

        for (
            int statisticIndex = 0;
            statisticIndex < Statistics.statisticsDependentNum;
            ++statisticIndex)
        {
            statistic = Instantiate(statisticText);
            statistic.transform.SetParent(
                statisticsViewContent.transform, false);
            statistic.transform.position =
                new Vector3(
                statistic.transform.position.x,
                statistic.transform.position.y - changeBy,
                statistic.transform.position.z);
            changeBy = changeBy + 30;

            statisticTextText = statistic.GetComponent<Text>();
            statisticTexts[statisticTextsIndex] = statisticTextText;
            statisticTextText.text =
                Statistics.statistics.
                statisticsDependentNames[statisticIndex] + ": " + 
                Statistics.statistics.getStatisticDependent(
                0, statisticIndex);

            ++statisticTextsIndex;
        }
    }

    public void Select()
    {
        int statisticTextsIndex = 0;

        if (thisDropdown.captionText.text.Equals("unavailable"))
        {
            for (
                int i = 0;
                i < Statistics.statisticsIndependentNum;
                ++i)
            {
                statisticTexts[statisticTextsIndex].text = 
                    Statistics.statistics.statisticsIndependentNames[i] + ": ";
                ++statisticTextsIndex;
            }
            for (
                int i = 0;
                i < Statistics.statisticsDependentNum;
                ++i)
            {
                statisticTexts[statisticTextsIndex].text = 
                    Statistics.statistics.statisticsDependentNames[i] + ": ";
                ++statisticTextsIndex;
            }
        }

        else
        {
            Statistics.statistics.CalculateStatisticsDependent(
                thisDropdown.value);

            for (
                int i = 0;
                i < Statistics.statisticsIndependentNum;
                ++i)
            {
                statisticTexts[statisticTextsIndex].text = 
                    Statistics.statistics.statisticsIndependentNames[i] + 
                    ": " + 
                    Statistics.statistics.getStatisticIndependent(
                    thisDropdown.value, i);
                ++statisticTextsIndex;
            }
            for (
                int i = 0;
                i < Statistics.statisticsDependentNum;
                ++i)
            {
                statisticTexts[statisticTextsIndex].text = 
                    Statistics.statistics.statisticsDependentNames[i] + 
                    ": " + 
                    Statistics.statistics.getStatisticDependent(
                    thisDropdown.value, i);
                ++statisticTextsIndex;
            }
        }
    }
}
