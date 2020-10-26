using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    Vector2 velocity;

    public bool isDead = false;

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

        transform.Translate(velocity * Time.deltaTime);

#if UNITY_STANDALONE || UNITY_EDITOR
        KeyBoardInputs();

#elif UNITY_ANDROID || UNITY_IOS
        MobileInputs();

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
        Die();
    }

    void Die()
    {
        Handheld.Vibrate();
        isDead = true;
    }

}
