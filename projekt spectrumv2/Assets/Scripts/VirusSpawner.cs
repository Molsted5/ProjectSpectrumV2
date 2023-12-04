using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{

    public float spawnRate;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject virusPrefab;
   

    private void Start()
    {
        StartCoroutine(Spawner());
        
    }

    private IEnumerator Spawner()
    {
        bool canSpawn = true;

        WaitForSeconds wait = new WaitForSeconds(spawnRate*Time.deltaTime);
        while (canSpawn)
        {
            yield return wait;

            int randPoint = Random.Range(0, spawnPoints.Length);
            Transform spawn = spawnPoints[randPoint];

            Instantiate(virusPrefab, spawn.position, Quaternion.identity);

        }

    }

}
