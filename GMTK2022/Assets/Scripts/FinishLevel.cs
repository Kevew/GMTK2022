using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public FadeIn fade;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerPrefs.SetInt("levelReached", Mathf.Max(int.Parse(SceneManager.GetActiveScene().name.Substring(5,2))+1, PlayerPrefs.GetInt("levelReached")));
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fade.startEnd();
            collision.transform.position = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ResetLevel>().resetPosition;
        }
    }
}