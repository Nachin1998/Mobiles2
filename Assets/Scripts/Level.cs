using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level part", menuName = "Level Part")]
public class Level : ScriptableObject
{
    public string startAnimation;
    public string loopAnimation;
    public float startingTime;
    public float endingTime;
}
