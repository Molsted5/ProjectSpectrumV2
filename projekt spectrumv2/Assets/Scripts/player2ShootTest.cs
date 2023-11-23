using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2ShootTest : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Transform firingPointLeft;
    [SerializeField] private Transform firingPointRight;
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
        if (Input.GetKey(KeyCode.J) && firingTimer <= 0f)
        {
            Shoot();
            firingTimer = firingRate;
        }
        else{

            firingTimer -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Rigidbody shootInstanceLeft = Instantiate(bulletPrefab, firingPointLeft.position, firingPointLeft.rotation) as Rigidbody;
        Rigidbody shootInstanceRight = Instantiate(bulletPrefab, firingPointRight.position, firingPointRight.rotation) as Rigidbody;

        shootInstanceLeft.velocity = currentLaunchforce * firingPointLeft.up;
        shootInstanceRight.velocity = currentLaunchforce * firingPointRight.up;

        //blasterAudio.clip = blasterFiring;
        //blasterAudio.Play();

    }
}
