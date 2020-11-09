using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class VirtualButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI messageToActivate;
    public float messageValue;
    public bool buttonPressed;
    public bool buttonHighlighted;

    Image button;
    TextMeshProUGUI text;

    Color startingButtonColor;
    Color startingTextColor;

    Color colorStart;
    Color colorEnd;
    float rate = 5;
    float colorTimer = 0;

    private void Start()
    {
        button = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        
        startingButtonColor = button.color;
        startingTextColor = text.color;

        colorStart.a = 1;
        colorEnd.a = 1;
    }

    private void Update()
    {
        if (buttonHighlighted)
        {
            colorTimer += Time.deltaTime * rate;
            Color newColor = Color.Lerp(colorStart, colorEnd, colorTimer);
            button.color = newColor;
            text.color = newColor;

            if (colorTimer >= 1)
            {
                colorTimer = 0;
                colorStart = button.color;
                colorEnd = new Color(Random.value, Random.value, Random.value, 1);
            }

            if (messageToActivate)
            {
                messageToActivate.text = "Time to win: " + messageValue.ToString("F2");
            }
        }
        else
        {
            if (messageToActivate)
            {
                messageToActivate.text = "";
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {       
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }    

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonHighlighted = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.color = startingButtonColor;
        text.color = startingTextColor;
        buttonHighlighted = false;
    }
}