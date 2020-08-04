using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] [Range(0f, 10f)] float speed = 3f;
    [SerializeField] [Range(-5f, 5f)] float spinSpeed = -2f;
    [SerializeField] int damage = 50;

    // Update is called once per frame
    void Update()
    {
        // Moving projectile
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);

        // Spinning projectile
        transform.Rotate(0, 0, spinSpeed);
    }


    // Method for collision handle
    private void OnTriggerEnter2D(Collider2D otherCollider) {

        // Time do deal some damage
        var health = otherCollider.GetComponent<Health>();
        var ataccker = otherCollider.GetComponent<Attacker>();

        // Checks if projectile collided with an ataccker and if it has health
        if(ataccker && health){
            health.DealDamage(damage);
            
            // Zucchinis gets destroyed after hit
            // if(this.name == "Zucchini(Clone)"){
            Destroy(gameObject);       // All projectiles get destroyed after hit... for now
            // }
        }
    }
}
