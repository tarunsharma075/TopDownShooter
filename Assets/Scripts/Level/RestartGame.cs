using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Button _restartbutton;  // Button to restart the game
    [SerializeField] private string scene;  // Name of the scene to load

    void Start()
    {
       _restartbutton= gameObject.gameObject.GetComponent<Button>();

        _restartbutton.onClick.AddListener(RestartButtonAction);
    }

    private void RestartButtonAction()
    {
        
        LevelManager.Instance.SetLevel(LevelManager.Level.LevelOne);  // Reset to Level One

       
        SceneManager.LoadScene(scene);

        SoundManager.Instance.PlayBackgroundMusic(SoundManager.GameSounds.BackGroundMusic);
        Time.timeScale = 1;
    }
}
