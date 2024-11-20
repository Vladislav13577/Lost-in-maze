using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Play);
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
