using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirusScript : MonoBehaviour
{
    
    GameManager gameManager;
  

    public void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); 
       
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
