using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float distanceToDestroy;
    Player player;

    SpriteRenderer sr;
    void Start()
    {
        player = FindObjectOfType<Player>();

        if (GetComponent<SpriteRenderer>() == null)
        {
            sr = GetComponent<SpriteRenderer>();

            switch (GameManager.Instance.currentLevel)
            {
                case GameManager.CurrentLevel.Level1:
                    sr.color = Color.blue;
                    break;

                case GameManager.CurrentLevel.Level2:
                    sr.color = Color.red;
                    break;

                case GameManager.CurrentLevel.Level3:
                    sr.color = Color.white;
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
