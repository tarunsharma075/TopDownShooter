using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerscore;
    [SerializeField] private GameObject _maingameobj;
    [SerializeField] private GameObject _nextlevelscreen;
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
            if (_score >= 150)
            {
                ProceedToNextLevel();


            }

        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelTwo)
        {
            if (_score >= 200)
            {
                ProceedToNextLevel();


            }


        }
        else if (LevelManager.Instance.GetLevel() == LevelManager.Level.LevelThree);
        {

            if (_score >= 100)
            {
                ProceedToNextLevel();


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
        _maingameobj.SetActive(false);
        _nextlevelscreen.SetActive(true);
    }
}
