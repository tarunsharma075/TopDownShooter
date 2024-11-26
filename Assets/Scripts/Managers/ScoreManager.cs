using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerscore;
    [SerializeField] private GameObject _mainGameScreen;
    [SerializeField] private GameObject _nextLevelScreen;
    //[SerializeField] private TextMeshProUGUI _playerscore;
    int _score = 0;


    private void Awake()
    {
        RefreshUi();
    }

    private void RefreshUi()
    {
        _playerscore.text = "Score "+_score;
       
    }

    public void IncreaseScore(int score)
    {
        _score += score;
        RefreshUi();

        if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelOne)
        {
            if (_score >= 500)
            {
                LevelLobbyManager.Instance.LevelCompletionLevelUnlocked("Level 1");
                ProceedToNextLevel();


            }

        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelTwo)
        {
            if (_score >= 750)
            {
                LevelLobbyManager.Instance.LevelCompletionLevelUnlocked("Level 2");
                ProceedToNextLevel();


            }


        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelThree);
        {

            if (_score >= 1000)
            {
                LevelLobbyManager.Instance.LevelCompletionLevelUnlocked("Level 3");
                SoundManager.Instance.StopBackGroundMusic();
                SoundManager.Instance.PlayBackgroundMusic(SoundManager.GameSounds.StageClear);
                
                _mainGameScreen.SetActive(false);
                _nextLevelScreen.SetActive(true);


            }
        }
    }

    internal void DecreaseScore(int decrement)
    {
       _score -= decrement;
        if (_score <= 0)
        {
            _score = 0;
            RefreshUi() ; 
        } 
        RefreshUi() ;
        
    }

    private void ProceedToNextLevel()
    {
         SoundManager.Instance.StopBackGroundMusic();
        _mainGameScreen.SetActive(false);
        _nextLevelScreen.SetActive(true);
    }
}
