using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainGameScreen;
    [SerializeField] private GameObject _lobby;
    [SerializeField] private Button _mainMenuButton;
    void Start()
    {
        _mainMenuButton.gameObject.GetComponent<Button>();
        _mainMenuButton.onClick.AddListener (OnClickAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SoundManager.Instance.StopBackGroundMusic();
            _mainGameScreen.SetActive(false);
            _lobby.SetActive(true);
        }
    }

    public void OnClickAction()
    {
        SoundManager.Instance.PlayBackgroundMusic(SoundManager.GameSounds.BackGroundMusic);
        SceneManager.LoadScene("Lobby");
    }
}
