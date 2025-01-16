using UnityEngine;

public class EndGameScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _deadScreen;
    [SerializeField] private GameObject _winScreen;

    private void Start()
    {
        Time.timeScale = 1.0f;
        _deadScreen.SetActive(false);
        _winScreen.SetActive(false);
    }

    public void ShowDeadScreen()
    {
        _deadScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowWinScreen()
    {
        _winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
