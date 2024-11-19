using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    void Start()
    {
        gameOverScreen.SetActive(false);
    }


    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameOverScreen.SetActive(true);
    }
}
