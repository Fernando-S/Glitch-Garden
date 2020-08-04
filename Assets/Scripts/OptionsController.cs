using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Header("Volume")]
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.2f;

    [Header("Difficulty")]
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // Sets default master volume
        if(volumeSlider){
            volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        }
        else{
            Debug.LogWarning("No Volume Slider");
        }

        // Sets default difficulty 
        if(difficultySlider){
            difficultySlider.value = PlayerPrefsController.GetDifficulty();
        }
        else{
            Debug.LogWarning("No Difficulty Slider");
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Finds Music Player
        var musicPlayer = FindObjectOfType<MusicPlayer>();

        // Updates Music Players's volume
        if(musicPlayer){
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else{
            Debug.LogWarning("No Music Player");
        }
    }


    // Method to save settings
    public void SaveSettings(){
        if(volumeSlider){
            PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        }

        if(difficultySlider){
            PlayerPrefsController.SetDifficulty(difficultySlider.value);
        }
    }


    // Method to save settings
    public void SetDefaultSettings(){
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
