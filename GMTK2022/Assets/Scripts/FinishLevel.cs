using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerPrefs.SetInt("levelReached", int.Parse(SceneManager.GetActiveScene().name.Substring(5,2))+1);
            SceneManager.LoadScene("LevelSelect");
        }
    }
}
