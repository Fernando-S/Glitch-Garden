using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;


    private void Start() {
        LabelButtonWithCost();
    }


    // Method to
    private void LabelButtonWithCost(){
        Text costText = GetComponentInChildren<Text>();

        if(!costText){
            Debug.LogWarning(name + "has no cost text!");
        }
        else{
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }


    // Method that handles mouse click
    private void OnMouseDown() {
        var selection = FindObjectsOfType<DefenderButton>();

        // Sets all the defenders as a dark shadow
        foreach(DefenderButton highlighted in selection){
            highlighted.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);;
        }

        // Highlight the selected defender
        GetComponent<SpriteRenderer>().color = Color.white;

        // Sets the selected defender
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);

    }
}
