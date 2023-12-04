using System.Collections;
using System.Collections.Generic;
using Unity.Content;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject virusPrefab;
    
      public IEnumerator Spawn(int wait)
        {   
            int randPoint = Random.Range(0, spawnPoints.Length);
            Transform spawn = spawnPoints[randPoint];

            yield return new WaitForSeconds(wait);
            Instantiate(virusPrefab, spawn.position, Quaternion.identity);
            yield break;
         }

    
}
