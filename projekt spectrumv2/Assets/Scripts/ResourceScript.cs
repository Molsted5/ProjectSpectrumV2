using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceScript : MonoBehaviour
{
    GameManager gameManager;


    public void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player2"))
        {
            if (gameManager.recourceCount < 4) {
                gameManager.recourceCount++;
                Destroy(gameObject); 
            }          
        }

        /*if (other.CompareTag("Bullet1"))
        {
            Destroy(gameObject);
        }*/
    }
}
