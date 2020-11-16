using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    Player player;
    AudioSource backgroundSong;
    public Slider slider;

    public static float volume = 1f;
    public AudioClip playerDeathSound;
    bool hasPlayed = false;

    void Start()
    {
        player = FindObjectOfType<Player>();
        backgroundSong = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (slider != null)
        {
            volume = slider.value;
        }

        backgroundSong.volume = volume;

        if (player != null)
        {
            if (player.deathAnimOn && !hasPlayed)
            {
                backgroundSong.PlayOneShot(playerDeathSound, 5f);
                hasPlayed = true;
            }
        }        
    }
}