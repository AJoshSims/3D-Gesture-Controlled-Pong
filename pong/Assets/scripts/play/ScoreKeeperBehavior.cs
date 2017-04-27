using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperBehavior : MonoBehaviour
{
    public static ScoreKeeperBehavior scoreKeeperBehavior;

    private int scorePlayer01;

    public Text scorePlayer01Text;

    private const string scorePlayer01Prefix = "player 1: ";

    private int scorePlayer02;

    public Text scorePlayer02Text;

    private const string scorePlayer02Prefix = "player 2: ";

    private void Awake()
    {
        if (scoreKeeperBehavior == null)
        {
            scoreKeeperBehavior = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scorePlayer01 = 0;
        scorePlayer01Text.text = scorePlayer01Prefix + scorePlayer01;

        scorePlayer02 = 0;
        scorePlayer02Text.text = scorePlayer02Prefix + scorePlayer02; 
    }

    internal void incrementScore(bool player01, int value)
    {
        if (player01 == true)
        {
            scorePlayer01 = scorePlayer01 + value;
            scorePlayer01Text.text = scorePlayer01Prefix + scorePlayer01;
        }
        else
        {
            scorePlayer02 = scorePlayer02 + value;
            scorePlayer02Text.text = scorePlayer02Prefix + scorePlayer02;
        }
    }

    private void Update()
    {
        if (
            (scorePlayer01 > 20)
            && (EffectExtraBalls
            .effectExtraBalls.enabled == false)
            && (Settings.settings.getGameplayEffectMode(
            Settings.extraBalls)
            == Settings.GameplayEffectMode.ScoreDependent))
        {
            EffectExtraBalls.effectExtraBalls.enabled = true;
        }
        if (
            (scorePlayer01 > 15)
            && (EffectPaddleSize
            .effectPaddleSize.enabled == false)
            && (Settings.settings.getGameplayEffectMode(
            Settings.shrinkPaddle) 
            == Settings.GameplayEffectMode.ScoreDependent))
        {
            EffectPaddleSize.effectPaddleSize.enabled = true;
        }
        if (
            (scorePlayer01 > 10)
            && (EffectRandomObstacles
            .effectRandomObstacles.enabled == false)
            && (Settings.settings.getGameplayEffectMode(
            Settings.obstacles)
            == Settings.GameplayEffectMode.ScoreDependent))
        {
            EffectRandomObstacles.effectRandomObstacles.enabled = true;
        }
        if (
            (scorePlayer01 > 5)
            && (EffectGoalZoneSegmentDisable
            .effectGoalZoneSegmentDisable.enabled == false)
            && (Settings.settings.getGameplayEffectMode(
            Settings.goalZoneSegmentDisable)
            == Settings.GameplayEffectMode.ScoreDependent))
        {
            EffectGoalZoneSegmentDisable
                .effectGoalZoneSegmentDisable.enabled = true;
        }
    }
}
