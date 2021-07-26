using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabs;

    bool spawn = true;

    IEnumerator Start()
    {
        while(spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        int index = Random.Range(0, attackerPrefabs.Length);
        Spawn(index);
    }

    private void Spawn(int index)
    {
        Attacker newAttacker = Instantiate(attackerPrefabs[index], transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }
}
