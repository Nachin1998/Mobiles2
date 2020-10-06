using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public Animator anim;

    public float stage1StartTime;
    public float stage2StartTime;
    public float stage3StartTime;
    public float gameEndTime;

    public PostProcessVolume ppv;
    float gameTimer = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;

        if(gameTimer >= stage1StartTime && gameTimer < stage2StartTime)
        {
            anim.SetBool("EasyRotationStart", true);
            anim.SetBool("EasyRotationLoop", true);
        }

        if(gameTimer >= stage2StartTime && gameTimer < stage3StartTime)
        {
            anim.SetBool("EasyRotationEnd", true);
            anim.SetBool("HardRotationStart", true);
            anim.SetBool("HardRotationLoop", true);
        }

        if (gameTimer >= stage3StartTime && gameTimer < gameEndTime)
        {
            anim.SetBool("HardRotationEnd", true);
            anim.SetBool("HardestRotationStart", true);
            anim.SetBool("HardestRotationLoop", true);
        }
    }
}
