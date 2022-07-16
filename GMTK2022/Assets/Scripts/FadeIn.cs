using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class FadeIn : MonoBehaviour
{
    public TextMeshProUGUI normalTime;
    public TextMeshProUGUI bestTime;
    public Animator anim;
    public ResetLevel resetInfo;
    void Start()
    {
        resetInfo = GetComponent<ResetLevel>();
        anim.gameObject.SetActive(false);
    }

    public void startEnd(string a)
    {
        float endTime = resetInfo.currTime;
        anim.gameObject.SetActive(true);
        normalTime.text = "Time: " + endTime.ToString();
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, Mathf.Min(PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name),endTime));
        bestTime.text = "Time: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name).ToString();
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void NextLevel()
    {
        string curr = SceneManager.GetActiveScene().name.Substring(5,2);
    }
}
