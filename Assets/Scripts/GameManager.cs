using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Gameplay", order = 0)]
    public Player player;
    public Animator anim;

    public float stage1StartTime;
    public float stage2StartTime;
    public float stage3StartTime;
    public float gameEndTime;

    [HideInInspector] public bool easyPartActive = false;
    [HideInInspector] public bool hardPartActive = false;
    [HideInInspector] public bool hardestPartActive = false;

    [Space]

    [Header("Effects")]
    public PostProcessVolume ppv;

    [Space]
    
    ColorGrading cg;

    [Header("Bloom")]
    public float maxBloom = 30;
    public float bloomSpeed = 10;
    float bloomValue = 0;
    Bloom bloom;

    Vignette vig;
    DepthOfField dof;

    [Header("Lens Distortion")]
    public float maxDistortion = 60f;
    public float distortionSpeed = 10f;
    float distortionValue = 0;
    LensDistortion ld;

    [Header("Chromatic Aberration")]
    public float maxAberration = 60f;
    public float aberrationSpeed = 10f;
    float aberrationValue = 0;
    ChromaticAberration ca;

    float gameTimer = 0;
    float timer = 0;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        ppv.profile.TryGetSettings(out cg);
        ppv.profile.TryGetSettings(out bloom);
        ppv.profile.TryGetSettings(out vig);
        ppv.profile.TryGetSettings(out dof);
        ppv.profile.TryGetSettings(out ld);
        ppv.profile.TryGetSettings(out ca);
    }

    void Update()
    {
        gameTimer += Time.deltaTime;
        
        if (gameTimer >= stage1StartTime && gameTimer < stage2StartTime)
        {
            easyPartActive = true;
            anim.SetBool("EasyRotationStart", true);
            anim.SetBool("EasyRotationLoop", true);
        }

        if (gameTimer >= stage2StartTime && gameTimer < stage3StartTime)
        {
            hardPartActive = true;
            anim.SetBool("EasyRotationEnd", true);
            anim.SetBool("HardRotationStart", true);
            anim.SetBool("HardRotationLoop", true);
        }

        if (gameTimer >= stage3StartTime && gameTimer < gameEndTime)
        {
            hardestPartActive = true;
            anim.SetBool("HardRotationEnd", true);
            anim.SetBool("HardestRotationStart", true);
            anim.SetBool("HardestRotationLoop", true);
        }

        /*if(timer <= 1)
        {
            timer += Time.deltaTime * aberrationSpeed;
        }
        else
        {
            timer = 0;
        }

        ca.intensity.value = Mathf.Lerp(1, 0, timer);*/
        
        if (easyPartActive)
        {
            bloomValue = Mathf.PingPong(Time.time * bloomSpeed, maxBloom);
            bloom.intensity.value = bloomValue;
        }

        if (hardPartActive)
        {
            bloomValue = Mathf.PingPong(Time.time * bloomSpeed, maxBloom);
            bloom.intensity.value = bloomValue;
        }

        if (hardestPartActive)
        {
            distortionValue = Mathf.PingPong(Time.time * distortionSpeed, maxDistortion * 2) - maxDistortion;
            ld.intensity.value = distortionValue;
        }
    }
}
