using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PopulateStatisticsView : MonoBehaviour
{
    public GameObject statisticText;

    void Start()
    {
        GameObject statistic = null;
        float changeBy = 0;

        for (
            int statisticIndex = 0;
            statisticIndex < Statistics.statisticsIndependentNum; 
            ++statisticIndex)
        {
            statistic = Instantiate(statisticText);
            statistic.transform.SetParent(gameObject.transform, false);
            statistic.transform.position =
                new Vector3(
                statistic.transform.position.x,
                statistic.transform.position.y - changeBy,
                statistic.transform.position.z);
            changeBy = changeBy + 30;
            statistic.GetComponent<Text>().text =
                Statistics.statistics.
                statisticsIndependentNames[statisticIndex] + ": " + statisticIndex;
        }

        for (
            int statisticIndex = 0;
            statisticIndex < Statistics.statisticsDependentNum;
            ++statisticIndex)
        {
            statistic = Instantiate(statisticText);
            statistic.transform.SetParent(gameObject.transform, false);
            statistic.transform.position =
                new Vector3(
                statistic.transform.position.x,
                statistic.transform.position.y - changeBy,
                statistic.transform.position.z);
            changeBy = changeBy + 30;
            statistic.GetComponent<Text>().text =
                Statistics.statistics.
                statisticsDependentNames[statisticIndex] + ": ";
        }
    }
}
