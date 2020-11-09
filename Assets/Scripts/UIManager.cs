using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameManager gm;
    public GameObject endMenu;
    public TextMeshProUGUI tutorialText;

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
        if(player.playerState != Player.PlayerState.Tutorial)
        {
            tutorialText.gameObject.SetActive(false);
        }

        if (player.isDead)
        {
            tutorialText.gameObject.SetActive(false);

            gameTimeText.text = "Time: " + gm.gameTimer.ToString("F2");
            StartCoroutine(ActivateDelayedMenu(endMenu, 1f));

            switch (gm.currentLevel)
            {
                case GameManager.CurrentLevel.Level1:
                case GameManager.CurrentLevel.Level2:
                    if (gm.finishedLevel)
                    {
                        messageText.text = "Congratulations! You won!";
                        nextLevelButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        replayButton.gameObject.SetActive(true);
                        messageText.text = "Better luck next time";
                    }
                    break;

                case GameManager.CurrentLevel.Level3:
                    if (gm.finishedLevel)
                    {
                        messageText.text = "Congratulations! You won!";
                    }
                    else
                    {
                        messageText.text = "Better luck next time";
                    }
                    replayButton.gameObject.SetActive(true);
                    break;

                default:
                    break;
            }           
        }
    }

    IEnumerator ActivateDelayedMenu(GameObject menu, float timeToAppear)
    {
        yield return new WaitForSeconds(timeToAppear);
        menu.SetActive(true);
    }
}
