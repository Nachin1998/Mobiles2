using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    // Start is called before the first frame update
    public float distanceUntilDestroyed;
    Rigidbody2D rb;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {        
        if(Vector2.Distance(player.gameObject.transform.position, transform.position) > distanceUntilDestroyed)
        {
            Destroy(gameObject);
        }       
    }
}
