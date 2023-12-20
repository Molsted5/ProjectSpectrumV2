using System.Collections;
using System.Collections.Generic;
using Unity.Content;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject virusPrefab;
    [HideInInspector] public int maxSpawn = 2;
    [HideInInspector] public int amountSpawned = 0;

    public IEnumerator Spawn(int wait)
        {   
            if( amountSpawned == maxSpawn ) {
                yield break;
            }
            int randPoint = Random.Range(0, spawnPoints.Length);
            Transform spawn = spawnPoints[randPoint];

            yield return new WaitForSeconds(wait);
            Instantiate(virusPrefab, spawn.position, Quaternion.identity);
            amountSpawned++;
            yield break;
         }

    
}
