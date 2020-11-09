using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Gameplay")]
    public Player player;
    public Animator camAnimHolder;

    public enum CurrentLevel
    {
        Level1, 
        Level2,
        Level3
    }
    public CurrentLevel currentLevel;
    public float gameEndTime = 100;

    public List<Level> levelParts;
    
    [HideInInspector] public List<bool> activeLevelPart;

    [HideInInspector] public bool finishedLevel = false;

    [Header("Effects")]
    public PostProcessVolume ppv;

    [Space]

    [Header("Color Grading")]
    public float maxTemperature = 30;
    public float temperatureSpeed = 10;
    ColorGrading cg;

    [Header("Bloom")]
    public float maxBloom = 30;
    public float bloomSpeed = 10;
    Bloom bloom;

    [Header("Vignette")]
    [Range(0, 0.3f)] public float maxVig = 0.2f;
    public float vigSpeed = 10;
    Vignette vig;

    [Header("Lens Distortion")]
    public float maxDistortion = 60f;
    public float distortionSpeed = 10f;
    LensDistortion ld;

    [HideInInspector] public float gameTimer = 0;
    [HideInInspector] public bool levelFinished = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

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
                        cg.temperature.value = Mathf.PingPong(Time.time * temperatureSpeed, maxTemperature);
                        vig.intensity.value = Mathf.PingPong(Time.time * vigSpeed, maxVig);
                        break;

                    case 2:
                        ld.intensity.value = Mathf.PingPong(Time.time * distortionSpeed, maxDistortion * 2) - maxDistortion;
                        break;

                    default:
                        break;
                }
            }
        }

        if(gameTimer >= gameEndTime)
        {
            finishedLevel = true;
        }
    }
}
