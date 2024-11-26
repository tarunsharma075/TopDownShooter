using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance => _instance;

     private Level _level = Level.LevelOne;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    

    public void SetLevel(Level level)
    {
        _level = level;
    }

    public Level GetLevel()
    {
        return _level;
    }

    public enum Level
    {
        LevelOne,
        LevelTwo,
        LevelThree,
    }
}
