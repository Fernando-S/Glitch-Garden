using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 1f;
    GameObject currentTarget;


    private void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }


    private void OnDestroy() {
        var levelController = FindObjectOfType<LevelController>();

        if(levelController){
            levelController.AttackerKilled();
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimation();
    }


    // Method to handle animation after killing a defender
    private void UpdateAnimation(){
        if(!currentTarget){
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }


    // Method to change speed via animation
    public void SetMovementSpeed(float speed){
        currentSpeed = speed;
    }


    // Method to attack
    public void Attack(GameObject target){
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }


    // Method to inflict damage to target
    public void StrikeTarget(int damage){
        // Checks if there's a target
        if(currentTarget){
            
            // Gets target health component
            Health targetHealth = currentTarget.GetComponent<Health>();

            // Checks if target has health
            if(targetHealth){
                // Do some damage
                targetHealth.DealDamage(damage);
            }
        }
    }
}
