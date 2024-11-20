using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private float speed = 4.5f;
    private float verticalInput;
    private float horizontalInput;
    public Transform mainCamera;
    private float mouseYinput;
    private float mouseXinput;
    public float sensetivity = 1;
    public bool stopGame;
    public AudioClip gameOverSound;
    public AudioSource audioSource;
    //private GameObject gameOverScreen;
    private float camVertRot = 0;

    void Start()
    {
        //gameOverScreen = GameObject.Find("GameOverScreen");
        //gameOverScreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseXinput = Input.GetAxis("Mouse X") * sensetivity;
        mouseYinput = Input.GetAxis("Mouse Y") * sensetivity;
        camVertRot -= mouseYinput;
        camVertRot = Mathf.Clamp(camVertRot, -90, 90);
        if (!stopGame)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
            transform.Rotate(Vector3.up * mouseXinput);
            mainCamera.localEulerAngles = Vector3.right * camVertRot;
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Anomaly"))
        {
            GameOver();
            stopGame = true;
            AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
            for (int i = 0; i < audioSources.Length; i++) 
                audioSources[i].Stop();
            audioSource.Stop();
            audioSource.PlayOneShot(gameOverSound);
        }
    }
    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //gameOverScreen.SetActive(true);
        SceneManager.LoadScene("GameOver");
    }
}
