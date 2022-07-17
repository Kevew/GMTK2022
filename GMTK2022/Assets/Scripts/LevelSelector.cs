using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelButtons;
    public TextMeshProUGUI[] textButtons;

    public TextMeshProUGUI recent;
    public TextMeshProUGUI best;

    private void Start()
    {
        float recentTemp = PlayerPrefs.GetFloat("recentEndless", 999999999f);
        float bestTemp = PlayerPrefs.GetFloat("bestEndless", 999999999f);
        if(recentTemp == 999999999f)
        {
            recent.text = "Recent: N/A";
        }
        else
        {
            recent.text = "Recent: " + recentTemp.ToString();
        }
        if(bestTemp == 999999999f)
        {
            best.text = "Best: N/A";
        }
        else
        {
            best.text = "Best: " + bestTemp.ToString();
        }
        int LevelReached = PlayerPrefs.GetInt("levelReached", 1);
        for(int i = 0;i < levelButtons.Length; i++)
        {
            if(i+1 > LevelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
        for(int i = 0;i < levelButtons.Length; i++)
        {
            string check = "Level";
            if(i <= 9)
            {
                check += "0" + (i+1).ToString();
            }
            else
            {
                check += (i+1).ToString();
            }
            if (!PlayerPrefs.HasKey(check))
            {
                PlayerPrefs.SetFloat(check, 99999f);
            }
            float temp = PlayerPrefs.GetFloat(check, 99999f);
            string textTemp = System.Math.Round(temp, 3).ToString();
            if(temp == 99999f)
            {
                textTemp = "N/A";
            }
            textButtons[i].text = textTemp;
        }
    }
    public void Select(string levelSelect)
    {
        int temp = int.Parse(levelSelect.Substring(5, 2));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + temp);
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }
}
