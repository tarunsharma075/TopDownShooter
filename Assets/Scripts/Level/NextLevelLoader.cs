using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private Button _nextlevelbutton;
    private int _nextsceneindex;
    void Start()
    {
         _nextsceneindex = SceneManager.GetActiveScene().buildIndex + 1;
        _nextlevelbutton.onClick.AddListener(NextButtonAction);
       

    }

    private void NextButtonAction()
    {
        SceneManager.LoadScene(_nextsceneindex);
        SoundManager.Instance.PlayBackgroundMusic(SoundManager.GameSounds.BackGroundMusic);
    }
}
