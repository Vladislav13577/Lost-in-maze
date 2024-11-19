using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button play;
    void Start()
    {
        play.onClick.AddListener(Play);
    }
    void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
