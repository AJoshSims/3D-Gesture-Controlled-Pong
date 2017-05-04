using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChoiceGameplayEffectMode : MonoBehaviour
{
    public int gameplayEffect;

    public void Awake()
    {
        UnityAction<int> choose = Choose;
        GetComponent<Dropdown>().onValueChanged.AddListener(choose);
    }

    public void Start()
    {
        switch (Settings.settings.getGameplayEffectMode(gameplayEffect))
        {
            case Settings.GameplayEffectMode.ScoreDependent:
                GetComponent<Dropdown>().value = 0;
                break;
            case Settings.GameplayEffectMode.Immediate:
                GetComponent<Dropdown>().value = 1;
                break;
            case Settings.GameplayEffectMode.Off:
                GetComponent<Dropdown>().value = 2;
                break;
        }
    }

    public void Choose(int i)
    {
        switch (GetComponent<Dropdown>().value)
        {
            case 0:
                Settings.settings.setGameplayEffectMode(
                    gameplayEffect, 
                    Settings.GameplayEffectMode.ScoreDependent);
                break;
            case 1:
                Settings.settings.setGameplayEffectMode(
                    gameplayEffect,
                    Settings.GameplayEffectMode.Immediate);
                break;
            case 2:
                Settings.settings.setGameplayEffectMode(
                    gameplayEffect,
                    Settings.GameplayEffectMode.Off);
                break;
        }
    }
}
