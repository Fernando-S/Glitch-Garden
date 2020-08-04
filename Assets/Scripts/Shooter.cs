using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject shootPoint;
    [SerializeField] int shotsCount = 3;

    private AttackerSpawner myLaneSpawner;
    private Animator animator;
    private GameObject projectileParent;
    const string PROJECTILE_PARENT = "Projectiles";


    private void Start() {
        // Sets what lane it's shooting
        SetLaneSpawner();

        // Sets it's animator controller
        animator = GetComponent<Animator>();

        // Sets projetile parent gameobject in hierarchy
        SetProjetileParent();
    }


    // Method to set a parent for instantiated projetiles in hierarchy
    private void SetProjetileParent(){
        // Tries to find existing parent
        projectileParent = GameObject.Find(PROJECTILE_PARENT);

        // Creates a new one if none was found
        if(!projectileParent){
            projectileParent = new GameObject(PROJECTILE_PARENT);
        }
    }


    private void Update() {
        // Checks if there's an attacker in this defender lane
        if(IsAttackerInLane()){
            animator.SetBool("isAttacking", true);
        }
        else{
            animator.SetBool("isAttacking", false);
        }
    }


    // Method that sets spawnder lane
    private void SetLaneSpawner(){
        // Find all enemy lane spawners
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        // Sets lane for defender
        foreach(AttackerSpawner spawner in spawners){
            // Had to cast to integer to avoid 0.000000001 unity math bug
            bool isCloseEnough = (Mathf.Abs((int) spawner.transform.position.y - (int) transform.position.y) <= Mathf.Epsilon);
            
            // Sets this spawner as the lane spawner against this defender
            if(isCloseEnough){
                myLaneSpawner = spawner;
            }
        }
    }


    // Method that checks is there's an spawner in lane
    private bool IsAttackerInLane(){
        // Checks if myLaneSpawner was already set
        if(myLaneSpawner){
            // Checks if there are no enemys in that lane
            if(myLaneSpawner.transform.childCount <= 0){
                return false;
            }
            else{
                return true;
            }
        }
        else{
            return false;
        }
    }


    // Single fire method
    private void Fire(){
        // Instantiates projectile
        GameObject newProjectile = Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;

        // Put it as child of Projectiles gameobject in hierarchy
        newProjectile.transform.parent = projectileParent.transform;
    }
    
    
    // Burst fire method
    public IEnumerator BurstFire(float bulletFireRate){
        for(int i = 0; i < shotsCount; i++){
            Fire();
            yield return new WaitForSeconds(bulletFireRate);
        }
    }


    // Fire and have a delay between shots
    public IEnumerator PowerFire(float delayToNextShot){
        Fire();
        yield return new WaitForSeconds(delayToNextShot);   // TODO - Didn't work
    }
}
