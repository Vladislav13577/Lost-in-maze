using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Button restartButton;

    void Start()
    {
        SceneManager.LoadScene("Menu");
        gameOverScreen.SetActive(false);

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        stopGame = true;
        gameOverScreen.SetActive(true);
    }
}
