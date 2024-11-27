using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int score;
    public int ghosts;

    public GameObject joyStick;
    public GameObject button1;
    public GameObject button2;

    Vector3 normalPost;

    public Color pressColor;
    public Color relaseColor;

    public bool playingPacman;

    public GameObject monitor;
    public Material planeGame, pacGame;
    public GameObject pacmanController, planeController;
    float timeUsed;
    public GameObject ui;
    public TMP_Text scoreText;


    private void Start()
    {
        normalPost = transform.position;
        ui.SetActive(false);
    }
    float turn = 0.1416f;

    private void Update()
    {
        if (playingPacman)
        {
            timeUsed += 1 * Time.deltaTime;
        }

        if (playingPacman && timeUsed > 60)
        {
            ui.SetActive(true);
            scoreText.text = $"Points:{score}";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playingPacman = false;
            monitor.GetComponent<MeshRenderer>().material = planeGame;
            pacmanController.GetComponent<PlatformController>().isPlaying = false;
            planeController.GetComponent<PlaneController>().isPlaneGame = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playingPacman = true;
            monitor.GetComponent<MeshRenderer>().material = pacGame;
            pacmanController.GetComponent<PlatformController>().isPlaying = true;

            planeController.GetComponent<PlaneController>().isPlaneGame = false;
        }
        MoveGame();
    }
    public void MoveGame()
    {
        if (Input.GetKey(KeyCode.D))
        {
            joyStick.transform.rotation = Quaternion.Euler(-65, 90, 90);
            transform.position = new Vector3(normalPost.x - turn, normalPost.y, normalPost.z);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            joyStick.transform.rotation = Quaternion.Euler(-90, 90, 90);
            transform.position = normalPost;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            joyStick.transform.rotation = Quaternion.Euler(-115, 90, 90);
            transform.position = new Vector3(normalPost.x + turn, normalPost.y, normalPost.z);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            joyStick.transform.rotation = Quaternion.Euler(-90, 90, 90);
            transform.position = normalPost;
        }
        if (Input.GetKey(KeyCode.S))
        {
            joyStick.transform.rotation = Quaternion.Euler(-115, 0, 180);
            transform.position = new Vector3(normalPost.x - turn, normalPost.y, normalPost.z);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            joyStick.transform.rotation = Quaternion.Euler(-90, 90, 90);
            transform.position = normalPost;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            button1.GetComponent<MeshRenderer>().material.color = pressColor;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            button1.GetComponent<MeshRenderer>().material.color = relaseColor;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            button2.GetComponent<MeshRenderer>().material.color = pressColor;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            button2.GetComponent<MeshRenderer>().material.color = relaseColor;

        }
    }
}
