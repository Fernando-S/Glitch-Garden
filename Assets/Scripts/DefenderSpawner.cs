using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender;
    private GameObject defenderParent;
    const string DEFENDER_PARENT = "Defenders";


    private void Start() {
        // Sets defender parent gameobject in hierarchy
        SetDefenderParent();
    }


    // Method to set a parent for instantiated defenders in hierarchy
    private void SetDefenderParent(){
        // Tries to find existing parent
        defenderParent = GameObject.Find(DEFENDER_PARENT);

        // Creates a new one if none was found
        if(!defenderParent){
            defenderParent = new GameObject(DEFENDER_PARENT);
        }
    }


    // Method to get mouse click
    private void OnMouseDown() {
        // Get mouse click position
        Vector2 defenderPos = GetSquareClicked();

        // Tries to spawn a defender
        AttemptToPlaceDefenderAt(defenderPos);

    }

    
    // Method to select defender
    public void SetSelectedDefender(Defender defenderToSelect){
        defender = defenderToSelect;
    }


    private void AttemptToPlaceDefenderAt(Vector2 gridPos){
        if(defender){
            var StarsDisplay = FindObjectOfType<StarsDisplay>();
            int defenderCost = defender.GetStarCost();

            if(StarsDisplay.HaveEnoughStars(defenderCost)){
                StarsDisplay.SpendStars(defenderCost);
                SpawnDefender(gridPos);
            }
        }
    }



    // Method to get click position
    private Vector2 GetSquareClicked(){
        // Getting mouse click position
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        // Converting it to game world unities
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

        // Snapping game world unities to grid
        Vector2 gridPos = SnapToGrid(worldPos);

        return gridPos;
    }


    // Method to snap click position to grid
    private Vector2 SnapToGrid(Vector2 worldPos){
        // Rounding position to integers
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);

        return new Vector2(newX, newY);
    }


    // Method to spawn defenders
    private void SpawnDefender(Vector2 worldPos){
        if(defender){
            // Instantiates a new defender
            Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;

            // Put it as chilf of Defenders gameobject in hierarchy
            newDefender.transform.parent = defenderParent.transform;
        }
    }

}
