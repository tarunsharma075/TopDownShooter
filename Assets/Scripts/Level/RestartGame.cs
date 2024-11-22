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

        // Add listener for the restart button
        _restartbutton.onClick.AddListener(RestartButtonAction);
    }

    private void RestartButtonAction()
    {
        // Reset level state if necessary
        LevelManager.Instance.SetLevel(LevelManager.Level.LevelOne);  // Reset to Level One

        // Reload the scene
        SceneManager.LoadScene(scene);

        // Ensure time scale is reset if it was paused
        Time.timeScale = 1;
    }
}
