using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidcontroller : MonoBehaviour
{

    Rigidbody rb;
    public float KnockbackStreangth;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)   //detect collision
    {
        if (other.gameObject.CompareTag("Bullet"))   //detect if tag on collided object is "Bullet"
        {
            rb.AddForce(Vector3.up * KnockbackStreangth, ForceMode.Impulse);   //Add force equal depending on set knockback streangth. Is also affected by object mass.
        }

        if ( other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))   //detect if tag on collided object is either "Player1" or "Player2"
        {
            //Physics.IgnoreCollision() skal bruge transform og sættes i void start
        }
    }

    private void spawn()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
