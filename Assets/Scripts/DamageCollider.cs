using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    // Handling collision
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        // Player lose a life
        FindObjectOfType<LivesDisplay>().TakeLife(1);

        // Destroy whatever the fuck collided with it
        Destroy(otherCollider.gameObject);
    }

}
