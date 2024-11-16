using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject gameOverScreen;
    public AudioClip gameOverSound;
    public Button restartButton;
    public AudioSource audioSource;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseXinput = Input.GetAxis("Mouse X");
        mouseYinput = Input.GetAxis("Mouse Y");
        
        if(!stopGame)
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
            GameOver();
        }
    }
    public void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        stopGame = true;
        gameOverScreen.SetActive(true);
        
        audioSource.PlayOneShot(gameOverSound);
    }
}
