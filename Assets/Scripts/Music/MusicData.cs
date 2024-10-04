using UnityEngine;

[CreateAssetMenu(fileName = "MusicData", menuName = "ScriptableObjects/MusicData")]
public class MusicData : ScriptableObject
{
    public AudioClip clip;
    public AudioClip fastClip;
    public float loopStartSample;
    public float loopEndSample;
    public float speedUpFactor = 1.25f;
}
