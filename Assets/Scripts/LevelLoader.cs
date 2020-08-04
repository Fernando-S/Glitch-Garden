using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float timeToWait = 3;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Wait if it's the splash screen
        if(currentSceneIndex == 0){
            StartCoroutine(WaitForTime());
        }
    }


    // Method to restart scene
    public void RestartScene(){
        // Time begins to move again
        Time.timeScale = 1;

        // Reloads current scene
        SceneManager.LoadScene(currentSceneIndex);
    }


    // Method to load Start Screen
    public void LoadStartScreen(){
        // Time begins to move again
        Time.timeScale = 1;

        // Loads Start Screen scene
        SceneManager.LoadScene("Start Screen");
    }


    // Method to load Options Screen
    public void LoadOptionsScreen(){
        // Time begins to move again
        Time.timeScale = 1;

        // Loads Start Screen scene
        SceneManager.LoadScene("Options Screen");
    }


    // Method to call next scene
    public void LoadNextScene(){
        if(currentSceneIndex < SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }


    // Method to wait time
    IEnumerator WaitForTime(){
        yield return new WaitForSeconds(timeToWait);
        
        // Changes Scene
        LoadNextScene();
    }


    // Method to call Game Over scene
    public void LoadGameOverScene(){
        SceneManager.LoadScene("Game Over Screen");
    }


    // Method to quit game
    public void QuitGame(){
        Application.Quit();
    }
}
