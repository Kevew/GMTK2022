using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public PlayerMovement player;
    public Vector3 resetPosition;
    public float currTime = 0f;
    public TextMeshProUGUI timer;
    
    [Header("LevelAnim")]
    public Animator anim;
    public TextMeshProUGUI gui;
    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.transform.position = resetPosition;
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            player.movementStart = false;
            currTime = 0f;
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gui.text = SceneManager.GetActiveScene().name;
    }

    private void FixedUpdate()
    {
        timer.text = System.Math.Round(currTime, 2).ToString();
        if (player.movementStart)
        {
            currTime += Time.deltaTime;
        }
    }


    public void startAnimation()
    {
        anim.SetTrigger("StartAnim");
    }
}
