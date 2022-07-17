using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    float nextTimer;
    public float nextTimerMin;
    public float nextTimerMax;
    float nextTime;

    public float powerMin;
    public float powerMax;

    public GameObject dice;
    private void FixedUpdate()
    {
        nextTimer += Time.deltaTime;
        if(nextTimer >= nextTime)
        {
            nextTime = Random.Range(nextTimerMin, nextTimerMax);
            nextTimer = 0;
            GenerateObjects();
        }
    }

    void GenerateObjects()
    {
        GameObject a = Instantiate(dice, transform.position, transform.rotation);
        a.GetComponent<Rigidbody>().AddForce(transform.up * Random.Range(powerMin,powerMax));
    }
}
