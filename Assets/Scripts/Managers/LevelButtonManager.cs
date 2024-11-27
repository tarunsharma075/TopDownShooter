using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class LevelButtonManager : MonoBehaviour
{
    [SerializeField] private Button _levelButton;
    [SerializeField] private string _levelToLoad;
    void Start()
    {

        _levelButton.GetComponent<Button>();
        _levelButton.onClick.AddListener(ClickAction);
    }

    private void  ClickAction()
    {
        LevelStatus CurrentLevelStatus = LevelLobbyManager.Instance.GetStatus(_levelToLoad);

        switch (CurrentLevelStatus)
        {

            case LevelStatus.Locked:
                SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.EnemyHit);
                Debug.Log("locked");
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.ButtonClick);
                SceneManager.LoadScene(_levelToLoad);

                break;
            case LevelStatus.Completed:
                SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.ButtonClick);
                SceneManager.LoadScene(_levelToLoad);
                break;

        }
    }
}
