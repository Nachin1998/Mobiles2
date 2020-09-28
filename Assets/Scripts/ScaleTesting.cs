using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTesting : MonoBehaviour
{
    // Start is called before the first frame update
    public bool keepAspectRatio;
    void Start()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        Vector2 worldSpace = new Vector2(topRightCorner.x * 2, topRightCorner.y * 2);
        Vector2 scaleFactor = new Vector2(worldSpace.x / sr.bounds.size.x, worldSpace.y / sr.bounds.size.y);

        if (keepAspectRatio)
        {
            if (scaleFactor.x > scaleFactor.y)
            {
                scaleFactor.y = scaleFactor.x;
            }
            else
            {
                scaleFactor.x = scaleFactor.y;
            }
        }

        gameObject.transform.localScale = new Vector3(scaleFactor.x * -1, scaleFactor.y * -1, 1);
    }
}
