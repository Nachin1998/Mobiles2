using UnityEngine;

[CreateAssetMenu(fileName = "Level part", menuName = "Level Part")]
public class Level : ScriptableObject
{
    public string startAnimationParameter;
    public string loopAnimationParameter;
    public float startingTime;
    public float endingTime;
}
