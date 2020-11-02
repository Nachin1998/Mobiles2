using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    //#region SINGLETON
    public static GameManager Instance;
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
    //#endregion

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

    [Header("Vignette")]
    [Range(0, 0.5f)] public float maxVig = 0.2f;
    public float vigSpeed = 10;
    float vigValue = 0;
    Vignette vig;

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

    [HideInInspector] public float gameTimer = 0;    

    void Start()
    {
        ppv.profile.TryGetSettings(out cg);
        ppv.profile.TryGetSettings(out bloom);
        ppv.profile.TryGetSettings(out vig);
        ppv.profile.TryGetSettings(out ld);
        ppv.profile.TryGetSettings(out ca);
    }

    void Update()
    {
        if (player.isDead)
            return;

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
            anim.SetBool("HardRotationStart", true);
            anim.SetBool("HardRotationLoop", true);
        }

        if (gameTimer >= stage3StartTime && gameTimer < gameEndTime)
        {
            hardestPartActive = true;
            anim.SetBool("HardestRotationStart", true);
            anim.SetBool("HardestRotationLoop", true);
        }
        
        if (easyPartActive)
        {
            bloomValue = Mathf.PingPong(Time.time * bloomSpeed, maxBloom);
            bloom.intensity.value = bloomValue;
        }

        if (hardPartActive)
        {
            aberrationValue = Mathf.Lerp(0, 1, Time.time * aberrationSpeed);
            ca.intensity.value = aberrationValue;
        }

        if (hardestPartActive)
        {
            distortionValue = Mathf.PingPong(Time.time * distortionSpeed, maxDistortion * 2) - maxDistortion;
            vigValue = Mathf.PingPong(Time.time * vigSpeed, maxVig);

            vig.intensity.value = vigValue;
            ld.intensity.value = distortionValue;
        }
    }
}
