using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;


    // Setter for Master Volume
    public static void SetMasterVolume(float volume){
        // Checks if volume is in range
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME){
            // Sets volume in PlayerPrefs
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
            Debug.Log("Master volume set to " + volume);
        }
        else
            Debug.Log("Master volume selected is out of range");
    }


    // Getter for Master Volume
    public static float GetMasterVolume(){
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    } 


    // Setter for difficulty
    public static void SetDifficulty(float difficulty){
        // Checks if difficulty is in range
        if(difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY){
            // Sets difficulty in PlayerPrefs
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
            Debug.Log("Difficulty set to " + difficulty);
        }
        else
            Debug.Log("Difficulty selected is out of range");
    }


    // Getter difficulty

    public static float GetDifficulty(){
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    } 
}
