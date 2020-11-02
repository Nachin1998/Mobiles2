using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Spawner")]
    public Transform spawnpoint;
    public float spawnerPingPongSpeed;
    public float spawnerPingPongValue;    

    [Header("Obstacles")]
    public float distanceFromPlayer;
    public float spawnRate;
    public List<Obstacle> obstacles;

    Player player;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        spawnpoint.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
            return;

        timer += Time.deltaTime;
        spawnpoint.transform.position = new Vector3(player.transform.position.x + distanceFromPlayer, Mathf.PingPong(Time.time * Random.Range(0, spawnerPingPongSpeed), spawnerPingPongValue * 2) - spawnerPingPongValue, 0);

        if(timer >= spawnRate)
        {
            int randomObst = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[randomObst], spawnpoint.transform.position, obstacles[randomObst].transform.rotation, transform);
            timer = 0;
        }
    }
}
