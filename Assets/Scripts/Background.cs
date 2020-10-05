using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float rotSpeed;

    Color colorStart;
    Color colorEnd;
    float rate = 1; 
    float colorTimer = 0;

    SpriteRenderer sr;
    void Start()
    {
        RenderSettings.skybox.SetColor("_Tint", new Color(0.0f, 30.0f / 255.0f, 0.0f, 1.0f));
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

        colorTimer += Time.deltaTime * rate;
        sr.material.color = Color.Lerp(colorStart, colorEnd, colorTimer);

        if (colorTimer >= 1)
        {
            colorTimer = 0;
            colorStart = sr.material.color;
            colorEnd = new Color(Random.value, Random.value, Random.value);
        }
    }
}
