using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    const string START_SCREEN_NAME = "Start Screen";

    // Singleton method
    private void SetUpSingleton(){
        int numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        // Checks if menu music was already instantiated and destroy the new one if it was
        if (numberOfMusicPlayers > 1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        // Sets menu music if it's Start Screen scene
        if(SceneManager.GetActiveScene().name == START_SCREEN_NAME){
            SetUpSingleton();
        }
        // Sets level music if it's any other scene that has a Music Player gameobject 
        else{
            // Destroy all Music Players except for the one in this scene
            var musicPlayers = FindObjectsOfType<MusicPlayer>();
            foreach(MusicPlayer player in musicPlayers){
                if(player != this){
                    Destroy(player.gameObject);
                }
            }
        }

        // Sets volume
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    
    // Method to change music volume
    public void SetVolume(float volume){
        audioSource.volume = volume;
    }
}
