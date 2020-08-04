using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float _waitToLoad = 4f;


    // Method to count enemy spawned
    public void AttackerSpawned(){
        numberOfAttackers++;
    }


    // Method to count enemy killed
    public void AttackerKilled(){
        numberOfAttackers--;

        // Checks if all attackers are dead and there's no more time left
        if(numberOfAttackers <= 0 && levelTimerFinished){
            StartCoroutine(HandleWinCondition());
        }
    }


    // Method to handle wins
    IEnumerator HandleWinCondition(){
        if(winLabel){
            // Set win canvas active
            winLabel.SetActive(true);

            // Wait some time
            yield return new WaitForSeconds(_waitToLoad);
            // Loads next scene
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }

    }


    // Method to handle wins
    public void HandleLoseCondition(){
        // Set win canvas active
        loseLabel.SetActive(true);

        // ZAWAAAAAARUUUDOOOOO
        Time.timeScale = 0;
    }


    // Method to set when timer has finished
    public void SetLevelTimerFinished(){
        levelTimerFinished = true;

        // Calls method to stop enemy spawners
        StopSpawners();
    }


    // Method to stop spawning enemies
    private void StopSpawners(){
        // Gets all AttackerSpawners
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        // Makes each AttackerSpawner to stop spawning
        foreach(AttackerSpawner spawner in spawnerArray){
            spawner.StopSpawning();
        }
    }
}