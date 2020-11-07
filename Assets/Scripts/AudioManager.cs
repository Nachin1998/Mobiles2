using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Player player;
    AudioSource audioSource;

    public AudioClip playerDeathSound;
    bool hasPlayed = false;

    void Start()
    {
        player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(player.deathAnimOn && !hasPlayed)
        {
            audioSource.PlayOneShot(playerDeathSound, 5f);
            hasPlayed = true;
        }
    }
}