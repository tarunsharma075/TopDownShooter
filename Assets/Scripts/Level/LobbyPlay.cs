using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LobbyPlay : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private GameObject _playLobby;
    [SerializeField] private GameObject _levelLobby;
    void Start()
    {
        _play.onClick.AddListener(LevelLobby);
    }

    private void  LevelLobby()
    {
       _playLobby.SetActive(false);
       _levelLobby.SetActive(true);
    }
}
