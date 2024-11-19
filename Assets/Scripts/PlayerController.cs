using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private float speed = 4.5f;
    private float verticalInput;
    private float horizontalInput;
    private float rotateSpeed = 100;
    public Transform mainCamera;
    private float mouseYinput;
    private float mouseXinput;
    public bool stopGame;
    public AudioClip gameOverSound;
    public AudioSource audioSource;
    private GameManager gameManager;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseXinput = Input.GetAxis("Mouse X");
        mouseYinput = Input.GetAxis("Mouse Y");

        if (!stopGame)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * mouseXinput);
            mainCamera.Rotate(Vector3.left * rotateSpeed * Time.deltaTime * mouseYinput);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Anomaly"))
        {
            gameManager.GameOver();
            stopGame = true;
            audioSource.PlayOneShot(gameOverSound);
        }
    }
}
