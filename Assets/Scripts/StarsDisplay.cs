using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
     [SerializeField] int stars = 100;
    Text starText;


    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    
    // Method that updates stars display text
    private void UpdateDisplay(){
        starText.text = stars.ToString();
    }


    // Method that checks before buying something
    public bool HaveEnoughStars(int amount){
        return stars >= amount;
    }


    // Method to increase stars amount
    public void AddStars(int amount){
        stars += amount;
        UpdateDisplay();
    }


    // Method to spend stars
    public void SpendStars(int amount){

        // Checks if the player has enough stars to spend
        if(stars >= amount){
            stars -= amount;
            UpdateDisplay();
        }
    }
}
