using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesCollider : MonoBehaviour
{
    // Handling collision
    private void OnTriggerEnter2D(Collider2D otherCollider) {
        // Destroy whatever the fuck collided with it
        Destroy(otherCollider.gameObject);
    }

}
