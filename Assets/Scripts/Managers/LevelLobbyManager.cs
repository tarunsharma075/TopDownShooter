using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
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
       
    }
     
    public LevelStatus GetStatus(string LevelName)
    {
        int StatusValue = PlayerPrefs.GetInt(LevelName,0);
        return (LevelStatus)StatusValue;
    }

    public void LevelCompletionLevelUnlocked()
    {
        SetStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
        Scene CurrentScene = SceneManager.GetActiveScene();
        int NextSceneIndex = CurrentScene.buildIndex + 1;
        if (NextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            string NextLevelPath= SceneUtility.GetScenePathByBuildIndex(NextSceneIndex);
            string NextLevelName= System.IO.Path.GetFileNameWithoutExtension(NextLevelPath);

            SetStatus(NextLevelName,LevelStatus.Unlocked);
        }
        else
        {
            Debug.Log("Nothing Happened");
        }

    }

}
