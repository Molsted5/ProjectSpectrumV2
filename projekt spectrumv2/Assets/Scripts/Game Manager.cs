using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int respawnTime = 5;
    public bool canSpawn;
    VirusSpawner spawn;
    public int virusCount;
    public int recourceCount;
    public int depositCount;
    public int hackedFactories;
  
    void Start()
    {
        spawn = gameObject.GetComponent<VirusSpawner>();
        virusCount = 0;
        recourceCount = 0;
        depositCount = 0;
        hackedFactories = 0;
        canSpawn = true;

        // sæt start værdiger, resource, virus,
        // bool, kan værdiger ændres. 
        
    }

   
    void Update()
    {
        if (canSpawn) 
        {
            StartCoroutine(spawn.Spawn(respawnTime));
            canSpawn = false;
        }

        // ændring af værdiger
    }



}
