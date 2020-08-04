using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    float lives;
    Text livesText;


    // Start is called before the first frame update
    void Start()
    {
        // Handling lives depending on difficulty
        var difficulty = PlayerPrefsController.GetDifficulty();
        if(difficulty == 2){
            lives = 1;
        }
        else if(difficulty == 1){
            lives = 3;
        }
        else{
            lives = 5;
        }
        
        // Setting display for the first time
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }


    // Method to update lives display
    private void UpdateDisplay(){
        livesText.text = lives.ToString();
    }


    // Method to decrease lives
    public void TakeLife(int damage){
        // Player takes damage
        lives -= damage;
        UpdateDisplay();

        // When player have no more HP
        if(lives <= 0){
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
