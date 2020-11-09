using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        Tutorial,
        Gameplay
    }

    [Header("Player")]
    public PlayerState playerState;
    public float speed;

    public ParticleSystem psDeath;
    public ParticleSystem psTrail;

    public bool deathAnimOn = false;
    public bool isDead = false;

    Vector2 velocity;

    void Start()
    {
        switch (playerState)
        {
            case PlayerState.Tutorial:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;

            case PlayerState.Gameplay:
                transform.rotation = Quaternion.Euler(0, 0, 45);
                break;

            default:
                break;
        }

        velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        if (isDead)            
            return;

        switch (playerState)
        {
            case PlayerState.Tutorial:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(velocity * Time.deltaTime);
                Tutorial();
                break;

            case PlayerState.Gameplay:
                transform.Translate(velocity * Time.deltaTime);
#if UNITY_STANDALONE || UNITY_EDITOR
                KeyBoardInputs();

#elif UNITY_ANDROID || UNITY_IOS
                MobileInputs();

#endif
                break;

            default:
                break;
        }


    }

    void Tutorial()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerState = PlayerState.Gameplay;
            transform.rotation = Quaternion.Euler(0, 0, -45);
            Time.timeScale = 1;            
        }
        else
        {
            Time.timeScale = 0;
        }

#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                transform.rotation = Quaternion.Euler(0, 0, -45);
                Time.timeScale = 1;
                playerState = PlayerState.Gameplay;
            }
        else
        {
            Time.timeScale = 0;
        }
        }
#endif
    }

    void KeyBoardInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
    }

    void MobileInputs()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                transform.rotation = Quaternion.Euler(0, 0, -45);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                transform.rotation = Quaternion.Euler(0, 0, 45);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(Die());        
    }

    IEnumerator Die()
    {
        velocity = Vector2.zero;
        psDeath.Play();
        psTrail.Stop();

#if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
#endif

        deathAnimOn = true;

        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        isDead = true;
        yield return new WaitForSeconds(0.5f);


        psDeath.gameObject.SetActive(false);
    }

}
