using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    MapGenerator mg;
    Player player;
    void Start()
    {
        mg = FindObjectOfType<MapGenerator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
