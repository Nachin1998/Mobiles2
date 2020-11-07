using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float distanceToDestroy;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();        
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.transform.position, transform.position) >= distanceToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
