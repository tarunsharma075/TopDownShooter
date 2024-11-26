using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class MainMenuLogic : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;

        void Start()
        {
            _mainMenuButton.onClick.AddListener(LoadMainMenu);
        }

        private void  LoadMainMenu()
        {
        SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.ButtonClick);
        SoundManager.Instance.PlayBackgroundMusic(SoundManager.GameSounds.BackGroundMusic); 
        SceneManager.LoadScene("Lobby");
        }
    }
