using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    // Handling collision with defenders
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        // Gets what game object collided with it
        GameObject otherObject = otherCollider.gameObject;

        // Checks if it's a gravestone
        if(otherObject.GetComponent<Gravestone>()){
            // Jump that rock
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }
        // Checks if it's another type of defender
        else if(otherObject.GetComponent<Defender>()){
            // Attack that bastard
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
