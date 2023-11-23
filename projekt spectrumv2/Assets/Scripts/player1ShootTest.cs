using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1ShootTest : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private float currentLaunchforce = 20;
    //public AudioSource blasterAudio;
    //public AudioClip blasterFiring;

    float firingTimer;
    

    [SerializeField] private float firingRate = 0.5f;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && firingTimer <= 0f) { 
            Shoot();
            firingTimer = firingRate;
        }
        else{

            firingTimer -= Time.deltaTime;
        }
    }

    private void Shoot(){


       Rigidbody shootInstance = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation) as Rigidbody;
       shootInstance.velocity = currentLaunchforce * firingPoint.up;

        //blasterAudio.clip = blasterFiring;
        //blasterAudio.Play();

    }

    
}
