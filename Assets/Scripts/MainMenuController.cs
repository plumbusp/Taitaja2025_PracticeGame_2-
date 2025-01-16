using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _settingMenu;

    private void Start()
    {
        Time.timeScale = 1.0f;
        AudioManager.instance.PlayAudio(MusicType.HappyMusic);
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && _settingMenu.activeSelf)
        {
            HandleSettings();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void HandleSettings()
    {
        _settingMenu.SetActive(!_settingMenu.activeSelf);
        _startMenu.SetActive(!_settingMenu.activeSelf);
    }

    public void QuitGame()
    {
          Application.Quit();
    }
}
