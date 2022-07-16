using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
                check += "1" + i.ToString();
            }
            else
            {
                check += i.ToString();
            }
            float temp = PlayerPrefs.GetFloat(check, 99999f);
            string textTemp = temp.ToString();
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
}
