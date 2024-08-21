using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "ScriptableObjects/MusicData")]
public class MusicData : ScriptableObject
{
    public AudioClip clip;
    public AudioClip fastClip;
    public float loopStartSample;
    public float loopEndSample;

    // Add the speedUpFactor with a default value of 1.25f
    public float speedUpFactor = 1.25f;
}
