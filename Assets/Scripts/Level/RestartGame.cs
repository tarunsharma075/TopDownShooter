using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Button _restartbutton;  // Button to restart the game
     private int  scene;  // Name of the scene to load

    void Start()
    {
       _restartbutton= gameObject.gameObject.GetComponent<Button>();

        _restartbutton.onClick.AddListener(RestartButtonAction);
        scene= SceneManager.GetActiveScene().buildIndex;
    }

    private void RestartButtonAction()
    {


        SoundManager.Instance.PlaySfxSound(SoundManager.GameSounds.ButtonClick);
        SceneManager.LoadScene(scene);

        SoundManager.Instance.PlayBackgroundMusic(SoundManager.GameSounds.BackGroundMusic);
        Time.timeScale = 1;
    }
}
