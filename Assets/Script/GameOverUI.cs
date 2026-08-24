using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void OnYesButton()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void OnNoButton()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Home");

    }
}
