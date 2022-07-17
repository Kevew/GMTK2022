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

    public void startEnd()
    {
        float endTime = resetInfo.currTime;
        anim.gameObject.SetActive(true);
        normalTime.text = "Time: " + endTime.ToString();
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, Mathf.Min(PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name),endTime));
        bestTime.text = "Best Time: " + PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name).ToString();
        PlayerPrefs.Save();
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void NextLevel()
    {
        int curr = int.Parse(SceneManager.GetActiveScene().name.Substring(5,2));
        curr++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
