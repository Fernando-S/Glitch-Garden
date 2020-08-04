using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] int minSpawnDelay = 1;
    [SerializeField] int maxSpawnDealy = 5;

    public Attacker[] attackerPrefabArray;

    IEnumerator Start()
    {
        while(spawn){
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDealy));
            SpawnAttacker();
        }
    }


    public void StopSpawning(){
        spawn = false;
    }


    // Method to spawn attacker waves
    private void SpawnAttacker(){
        var attackerIndex = Random.Range(0, attackerPrefabArray.Length);

      
        Spawn(attackerPrefabArray[attackerIndex]);
    }


    // Method that spawns an attacker
    private void Spawn(Attacker myAttacker){
        // Instantianting objects as childs of eache Spawner
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
