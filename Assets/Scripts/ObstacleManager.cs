using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Spawner")]
    public Transform spawnpoint;
    public float posRange;

    [Header("Obstacles")]
    public float distanceFromPlayer;
    public float spawnRate;
    public List<Obstacle> obstacles;

    public float distanceToDestroy = 60;
    Player player;
    float timer;

    void Start()
    {
        player = FindObjectOfType<Player>();
        spawnpoint.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
            return;

        timer += Time.deltaTime;

        spawnpoint.transform.position = new Vector3(player.transform.position.x + distanceFromPlayer, spawnpoint.transform.position.y, 0);

        if (timer >= spawnRate)
        {
            int randomObst = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[randomObst].gameObject, spawnpoint.transform.position, obstacles[randomObst].transform.rotation, transform);
            spawnpoint.transform.position = new Vector3(player.transform.position.x + distanceFromPlayer, Random.Range(-posRange, posRange), 0);
            timer = 0;
        }        
    }
}
