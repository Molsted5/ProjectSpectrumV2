using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScript : MonoBehaviour
{
    
    GameManager gameManager;
    VirusSpawner spawn;

    public void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawn = GameObject.Find("Game Manager").GetComponent<VirusSpawner>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            gameManager.virusCount++;

            Destroy(gameObject);
        }

        if(other.CompareTag("Bullet2"))
        {
            gameManager.canSpawn = true;

            Destroy(gameObject);
        }
    }
}
