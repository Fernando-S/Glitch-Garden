using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFX;


    // Method to calculate damage and destroy gameobject when it dies
    public void DealDamage(int damage){
        health -= damage;

        if(health <= 0){
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }


    // Particle effect for death
  private void TriggerDeathVFX()
  {
    // Checks if there's a deathVFX reffered
    if(deathVFX){
        // Instantiate the VFX
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, deathVFX.transform.rotation);

        // Destroy VFX after 1 second
        Destroy(deathVFXObject, 1f);
    }
  }
}
