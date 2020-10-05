using System.Collections;
using System.Collections.Generic;
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
    Vector2 velocity;

    public GameObject mainTile;

    public bool isDead = false;
    void Start()
    {
        if(playerState == PlayerState.Tutorial)
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 45));
        }

        velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0, 0, -90);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.Rotate(0, 0, 90);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isDead = true;        
    }
}
