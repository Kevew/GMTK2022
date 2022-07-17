using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public ResetLevel reset;

    bool isEndless;
    public TextMeshProUGUI recentText;
    public EndlessRunner end;
    public TextMeshProUGUI bestText;
    public GameObject camRot;
    public GameObject playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Endless")
        {
            isEndless = true;
        }
        else
        {
            isEndless = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camRot.GetComponent<CameraMovement>().enabled = true;
        playerMovement.GetComponent<PlayerMovement>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (isEndless)
        {
            recentText.text = "Current: " + Mathf.Round(end.highest).ToString();
            bestText.text = "Best: " + PlayerPrefs.GetFloat("bestEndless");
        }
        else
        {
            recentText.text = "Current: " + reset.currTime.ToString();
            bestText.text = "Best: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name);
        }
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        playerMovement.GetComponent<PlayerMovement>().enabled = false;
        camRot.GetComponent<CameraMovement>().enabled = false;
    }
    public void MainMenu()
    {
        if (isEndless)
        {
            PlayerPrefs.SetFloat("recentEndless", Mathf.Round(end.highest));
            PlayerPrefs.SetFloat("bestEndless", Mathf.Max(PlayerPrefs.GetFloat("bestEndless", Mathf.Round(end.highest))));
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelector()
    {
        if (isEndless)
        {
            PlayerPrefs.SetFloat("recentEndless", Mathf.Round(end.highest));
            PlayerPrefs.SetFloat("bestEndless", Mathf.Max(PlayerPrefs.GetFloat("bestEndless", Mathf.Round(end.highest))));
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }

}
