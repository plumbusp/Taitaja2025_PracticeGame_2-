using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScenesController : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
