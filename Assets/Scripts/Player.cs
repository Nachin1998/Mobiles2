using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour//, IDragHandler, IPointerUpHandler, IPointerDownHandler
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
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }

        velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        transform.Translate(velocity * Time.deltaTime);

#if UNITY_STANDALONE || UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }

#elif UNITY_ANDROID || UNITY_IOS
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
#endif
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isDead = true;        
    }

    /*public void OnPointerDown(PointerEventData eventData)
    {
        background.color = highlightColor;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = LocalPos(eventData);
        if (pos.magnitude > limit)
        {
            pos = pos.normalized * limit;
        }

        float x = pos.x / limit;
        float y = pos.y / limit;

        InputManager.Instance.SetAxis("Horizontal" + player, x);
        InputManager.Instance.SetAxis("Vertical" + player, y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.color = startingColor;
        InputManager.Instance.SetAxis("Horizontal" + player, 0);
        InputManager.Instance.SetAxis("Vertical" + player, 0);
    }

    void OnDisable()
    {
        InputManager.Instance.SetAxis("Horizontal" + player, 0);
        InputManager.Instance.SetAxis("Vertical" + player, 0);
    }

    Vector2 LocalPos(PointerEventData eventData)
    {
        Vector2 newPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, eventData.position, eventData.enterEventCamera, out newPos);
        return newPos;
    }*/
}
