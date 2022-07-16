using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Transform FirstGamePosition;
    public Transform SecondGamePosition;
    public Transform cam;
    bool moving = false;
    bool moving2 = false;

    public float speed;
    

    public void StartGame()
    {
        moving = true;
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    void FixedUpdate()
    {
        if (moving)
        {
            Vector3 dir = FirstGamePosition.position - cam.position;
            float distanceThisFrame = speed * Time.deltaTime;
            if(dir.magnitude <= distanceThisFrame)
            {
                moving = false;
                moving2 = true;
            }
            cam.Translate(dir.normalized * distanceThisFrame, Space.World);
            
        }

        if (moving2)
        {
            Vector3 dir = SecondGamePosition.position - cam.position;
            float distanceThisFrame = speed * Time.deltaTime;
            if (dir.magnitude <= distanceThisFrame)
            {
                SceneManager.LoadScene("LevelSelect");
            }
            cam.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }

}
