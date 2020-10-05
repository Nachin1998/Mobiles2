using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{    
    public List<MapTile> mapTiles;
    public float distanceFromPlayer;
    public float maxTimer;

    Player player;
    Vector2 velocity;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        velocity = new Vector2(player.speed, 0);
        timer = 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector2(player.transform.position.x + distanceFromPlayer, 0);

        if(timer > maxTimer)
        {
            int randomMap = Random.Range(0, mapTiles.Count);
            Instantiate(mapTiles[randomMap], transform.position, Quaternion.identity);
            timer = 0; 
        }
    }
}
