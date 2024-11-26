using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static LevelManager;

public class LevelLobbyManager : MonoBehaviour
{

    private static LevelLobbyManager _instance;
   public static LevelLobbyManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
           Destroy(gameObject);
        }
    }
    void Start()
    {
        if (GetStatus("Level 1") == LevelStatus.Locked) {

            SetStatus("Level 1", LevelStatus.Unlocked);
        }
    }

  

    public void  SetStatus(string LevelName, LevelStatus _levelStatus)
    {
       PlayerPrefs.SetInt(LevelName,(int)_levelStatus);
        PlayerPrefs.Save();
    }
     
    public LevelStatus GetStatus(string LevelName)
    {
        int LevelStatus = PlayerPrefs.GetInt(LevelName,0);
        return (LevelStatus)LevelStatus;
    }

    
}
