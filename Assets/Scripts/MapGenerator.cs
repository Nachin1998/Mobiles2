using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{    
    public List<MapTile> mapTiles;

    public float distanceBetweenTiles = 19.2f;
    public float distanceToSpawn = 0;

    float spawnPos = 0;
    Player player;

    // Start is called before the first frame update
    void Start()
    {        
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
            return;

        if (IsWithingSpawningDistance())
        {
            spawnPos += distanceBetweenTiles;
            int randomMap = Random.Range(0, mapTiles.Count);
            Instantiate(mapTiles[randomMap].gameObject, new Vector2(spawnPos, 0), Quaternion.identity, transform);
        }
    }

    bool IsWithingSpawningDistance()
    {
        return spawnPos - player.transform.position.x < distanceToSpawn;
    }
}
