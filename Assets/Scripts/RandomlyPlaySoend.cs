using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomlyPlaySoend : MonoBehaviour
{
    public AudioSource audioSource;
    public bool canPlay = false;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public float culmChance;
    public float threshHold = 10;
    void Update()
    {
        if (culmChance < threshHold)
        {
            culmChance += Random.value * Time.deltaTime;
        }
        else
        {
            if (!canPlay)
                return;
            audioSource.Play();
            culmChance = 0;
        }
    }

    void OnBecameInvisible()
    {
        canPlay = false;
    }

    void OnBecameVisible()
    {
        canPlay = true;
    }
}
