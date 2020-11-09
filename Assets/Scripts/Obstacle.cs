using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float distanceToDestroy;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();

        if (GetComponent<SpriteRenderer>() != null)
        {
            switch (GameManager.Instance.currentLevel)
            {
                case GameManager.CurrentLevel.Level1:
                    GetComponent<SpriteRenderer>().color = Color.blue;
                    break;

                case GameManager.CurrentLevel.Level2:
                    GetComponent<SpriteRenderer>().color = Color.red;
                    break;

                case GameManager.CurrentLevel.Level3:
                    GetComponent<SpriteRenderer>().color = Color.white;
                    break;

                default:
                    break;
            }
        }              
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
