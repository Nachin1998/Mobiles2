using UnityEngine;

public class MapTile : MonoBehaviour
{
    // Start is called before the first frame update
    public float distanceUntilDestroyed;
    Player player;
    

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (player.isDead)
            return;

        float distanceFromPlayer = (player.gameObject.transform.position - transform.position).x;
        if (distanceFromPlayer > distanceUntilDestroyed)
        {
            Destroy(gameObject);
        }
    }
}
