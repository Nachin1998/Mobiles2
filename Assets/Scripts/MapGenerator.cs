using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<MapTile> mapTiles;

    public float distanceBetweenTiles = 19.2f;
    public float distanceToSpawn = 0;
    public float distanceUntilDestroyed = 0;

    int[] rotationValues = new int[] { 0, 180 };
    int[] scaleValues = new int[] { -1, 1 };

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
            GameObject GO = Instantiate(mapTiles[randomMap].gameObject, new Vector2(spawnPos, 0), Quaternion.identity, transform);

            int randomRot = Random.Range(0, rotationValues.Length);
            int randomScaleX = Random.Range(0, scaleValues.Length);
            int randomScaleY = Random.Range(0, scaleValues.Length);

            GO.transform.localScale = new Vector2(scaleValues[randomScaleX], scaleValues[randomScaleY]);
            GO.transform.Rotate(rotationValues[randomRot], 0, 0);
        }
    }

    bool IsWithingSpawningDistance()
    {
        return spawnPos - player.transform.position.x < distanceToSpawn;
    }
}
