using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Animator anim;
    float gameTimer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;

        Debug.Log(gameTimer);
        if(gameTimer >= 10f && gameTimer < 30f)
        {
            anim.SetBool("EasyRotationStart", true);
            anim.SetBool("EasyRotationLoop", true);
        }

        if(gameTimer >= 30f && gameTimer < 45f)
        {
            anim.SetBool("EasyRotationEnd", true);
            anim.SetBool("HardRotationStart", true);
            anim.SetBool("HardRotationLoop", true);
        }
    }
}
