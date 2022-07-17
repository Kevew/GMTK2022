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
            other.gameObject.GetComponent<PlayerMovement>().changeSpeed(5);
            player.movementStart = false;
            currTime = 0f;
            anim.SetTrigger("StartAnim");
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gui.text = SceneManager.GetActiveScene().name;
        anim.SetTrigger("StartAnim");
    }

    private void FixedUpdate()
    {
        timer.text = System.Math.Round(currTime, 2).ToString();
        if (player.movementStart)
        {
            currTime += Time.deltaTime;
        }
    }
}
