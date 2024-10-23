using UnityEngine;

public class MusicRandomizer : MonoBehaviour { 
    [SerializeField] private string[] musicList;
    [SerializeField] private string musicFallback = "LevelOverworld";

    public MusicData GetMusic() {

        MusicData usedMusic = null;
 
        if(musicList.Length != 0) {
            if (musicList.Length == 1) { //only one entry in array
                usedMusic = LoadMusic(musicList[0]);
            } else {
                int randMusicId = Random.Range(0, musicList.Length);
                usedMusic = LoadMusic(musicList[randMusicId]);
            }
        }

        if (usedMusic != null) 
            return usedMusic;

        usedMusic = LoadMusic(musicFallback);
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