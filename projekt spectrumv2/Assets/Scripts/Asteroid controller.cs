using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Asteroidcontroller : MonoBehaviour
{

    Rigidbody rb;
    public float KnockbackStreangth;
    public float AsteroidHealth;
    public GameObject Collectable;
    Vector3 test;
    Transform shipTransform;
    public CapsuleCollider CC;
    public float offset = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        test = new Vector3(110f, 110f, 110f);
        rb = GetComponent<Rigidbody>();
        


    }

    Vector3 CalculatedPosition()
    {
        shipTransform = GameObject.Find("Player2(done)").GetComponent<Rigidbody>().transform;
        Vector3 shipPosition = shipTransform.position;
        Vector3 asteroidePosition = rb.transform.position;

        Vector3 dir = (shipPosition - asteroidePosition).normalized;
        Vector3 pos = this.CC.radius * (dir * offset);
        return pos;
    }

    private void OnCollisionEnter(Collision other)   //detect collision
    {
        
        if (other.gameObject.CompareTag("Bullet"))   //detect if tag on collided object is "Bullet"
        {
            rb.AddForce(Vector3.up * KnockbackStreangth, ForceMode.Impulse);   //Add force equal depending on set knockback streangth. Is also affected by object mass.
        }

        if (other.gameObject.CompareTag("Bullet2"))
        {
            rb.AddForce(Vector3.up * KnockbackStreangth, ForceMode.Impulse);   //Add force equal depending on set knockback streangth. Is also affected by object mass.
            if (AsteroidHealth <= 10)
            {
                AsteroidHealth--;
            }

            if (AsteroidHealth == 4)
            {
               GameObject dropInstance = Instantiate(Collectable, CalculatedPosition(), Quaternion.identity);
            }   

            if (AsteroidHealth == 3)
            {
                GameObject dropInstance = Instantiate(Collectable, CalculatedPosition(), Quaternion.identity);
            }

            if (AsteroidHealth < 1)
            {
                Instantiate(Collectable, CalculatedPosition(), Quaternion.identity);
                Destroy(gameObject);
                
            }
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
