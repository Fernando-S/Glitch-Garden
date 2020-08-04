using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 50;


    // Method to call AddStars from StarsDisplay script
    public void AddStars(int amount) {
        FindObjectOfType<StarsDisplay>().AddStars(amount);
    }


    // Getter for starCost
    public int GetStarCost(){
        return starCost;
    }
}
