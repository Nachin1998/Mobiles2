using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameManager gm;
    public TextMeshProUGUI gameTimeText;
    public TextMeshProUGUI messageText;
    public GameObject deathMenu;

    Player player;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        player = FindObjectOfType<Player>();
        deathMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            StartCoroutine(ActivateDelayedMenu(deathMenu, 1f));
            switch (GameManager.Instance.gameTimer)
            {
                
            }
            gameTimeText.text = gm.gameTimer.ToString("F2");
        }
    }

    IEnumerator ActivateDelayedMenu(GameObject menu, float timeToAppear)
    {
        yield return new WaitForSeconds(timeToAppear);
        menu.SetActive(true);
    }
}
