using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;

public class LevelSelector : MonoBehaviour
{

    public Button[] levelButtons;
    public TextMeshProUGUI[] textButtons;

    private void Start()
    {
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
        SceneManager.LoadScene(levelSelect);
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("Endless");
    }
}
