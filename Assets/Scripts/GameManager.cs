using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public Player player;
    public Animator camAnimHolder;

    public List<Level> levelParts;
    [HideInInspector] public List<bool> activeLevelPart;

    [HideInInspector] public bool gameOver = false;

    [Header("Effects")]
    public PostProcessVolume ppv;

    [Space]

    ColorGrading cg;

    [Header("Bloom")]
    public float maxBloom = 30;
    public float bloomSpeed = 10;
    Bloom bloom;

    [Header("Vignette")]
    [Range(0, 0.5f)] public float maxVig = 0.2f;
    public float vigSpeed = 10;
    Vignette vig;

    [Header("Lens Distortion")]
    public float maxDistortion = 60f;
    public float distortionSpeed = 10f;
    LensDistortion ld;

    [HideInInspector] public float gameTimer = 0;

    void Start()
    {
        //player = FindObjectOfType<Player>();
        //camAnimHolder = GameObject.Find("CameraHolder").GetComponent<Animator>();
        //ppv = FindObjectOfType<PostProcessVolume>();

        ppv.profile.TryGetSettings(out cg);
        ppv.profile.TryGetSettings(out bloom);
        ppv.profile.TryGetSettings(out vig);
        ppv.profile.TryGetSettings(out ld);

        for (int i = 0; i < levelParts.Count; i++)
        {
            activeLevelPart.Add(false);
        }
    }

    void Update()
    {
        if (player.isDead)
            return;

        gameTimer += Time.deltaTime;

        for (int i = 0; i < levelParts.Count; i++)
        {
            if (gameTimer >= levelParts[i].startingTime && gameTimer < levelParts[i].endingTime)
            {
                activeLevelPart[i] = true;
                camAnimHolder.SetBool(levelParts[i].startAnimation, true);
                camAnimHolder.SetBool(levelParts[i].loopAnimation, true);
            }

            if (activeLevelPart[i])
            {
                switch (i)
                {
                    case 0:
                        bloom.intensity.value = Mathf.PingPong(Time.time * bloomSpeed, maxBloom);
                        break;

                    case 1:
                        vig.intensity.value = Mathf.PingPong(Time.time * vigSpeed, maxVig);
                        break;

                    case 2:
                        //ld.intensity.value = Mathf.PingPong(Time.time * distortionSpeed, maxDistortion * 2) - maxDistortion;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
