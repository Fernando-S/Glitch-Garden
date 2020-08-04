using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    // Handling collision with defenders
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        // Gets what game object collided with it
        GameObject otherObject = otherCollider.gameObject;

        // Checks if it's a defender
        if(otherObject.GetComponent<Defender>()){
            // Attack that bastard
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
