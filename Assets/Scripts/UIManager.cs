using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameManager gm;
    public GameObject endMenu;
    public TextMeshProUGUI gameTimeText;
    public TextMeshProUGUI messageText;

    public VirtualButton nextLevelButton;
    public VirtualButton replayButton;

    Player player;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();

        player = FindObjectOfType<Player>();
        endMenu.SetActive(false);

        nextLevelButton.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            gameTimeText.text = "Time: " + gm.gameTimer.ToString("F2");
            StartCoroutine(ActivateDelayedMenu(endMenu, 1f));
            if (gm.finishedLevel)
            {
                messageText.text = "Congratulations! You won!";
                nextLevelButton.gameObject.SetActive(true);
            }
            else
            {
                messageText.text = "Better luck next time";
                replayButton.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator ActivateDelayedMenu(GameObject menu, float timeToAppear)
    {
        yield return new WaitForSeconds(timeToAppear);
        menu.SetActive(true);
    }
}
