﻿using System;
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
            _mainMenuButton.onClick.AddListener(LoadMaintMenu);
        }

        private void  LoadMaintMenu()
        {
        SceneManager.LoadScene(0);
        }
    }