using UnityEngine;

public class MusicRandomizer : MonoBehaviour { 
    [SerializeField] private string[] musicList;
    [SerializeField] private string musicNoRandom = "LevelOverworld";

    public MusicData GetMusic() {

        MusicData usedMusic;

        if(Settings.Instance.musicRand && musicList.Length != 0) {
            if (musicList.Length == 1) { //only one entry in array
                usedMusic = LoadMusic(musicList[0]);
            } else {
                int randMusicId = Random.Range(0, musicList.Length);
                usedMusic = LoadMusic(musicList[randMusicId]);
            }
        } else { // disabled randomizer
            usedMusic = LoadMusic(musicNoRandom);
        }

        if (usedMusic != null) 
            return usedMusic;

        Debug.Log("ERROR: Music could not be loaded! Trying musicNoRandom...");
        usedMusic = LoadMusic(musicNoRandom);
        if(usedMusic != null)
            return usedMusic;

        Debug.Log("WARNING: Music loading failed! Trying default music...");
        LoadMusic("LevelOverworld");
        if(usedMusic != null) 
            return usedMusic;

        Debug.Log("ERROR: Music loading failed! Check the Music data any try again.");

        Destroy(this);
        return usedMusic;
    }
    private MusicData LoadMusic(string name){
        string path = "Scriptables/Music/Music";
        string fileName = path+name;

        //load from resources folder
        MusicData loadedMusic = Resources.Load(fileName) as MusicData;

        //check loader null
        if(loadedMusic == null) {
            Debug.Log("ERROR: Music \'"+name+"\' doesnt exist! Path: Resources/"+fileName+".");
            return null;
        }

        return loadedMusic;
    }
}