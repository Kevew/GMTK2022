using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> shuffle = new List<AudioClip>();

    private AudioSource audioPlay;

    float currsong = 0f;
    float songlength = 0f;
    void Start()
    {
        currsong = 0f;
        audioPlay = GetComponent<AudioSource>();
        realSuffle();
    }

    void Update()
    {
        if (currsong < songlength)
        {
            currsong += Time.deltaTime;
        }
        else
        {
            realSuffle();
        }
    }

    public void realSuffle()
    {
        currsong = 0f;
        int a = Random.Range(0, shuffle.Count);
        while (shuffle[a].length == songlength)
        {
            a = Random.Range(0, shuffle.Count);
        }
        songlength = shuffle[a].length;
        audioPlay.clip = shuffle[a];
        audioPlay.Play();
    }
}