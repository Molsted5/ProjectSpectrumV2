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

    public AudioSource asteroideSource;
    public AudioClip dropSound;
  
    
    public CapsuleCollider CC;
    public float offset = 1.5f;
    GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        test = new Vector3(110f, 110f, 110f);
        rb = GetComponent<Rigidbody>();
    }

    Vector3 CalculatedPosition()
    { 

       

        Vector3 shipPosition = gameManager.shipTransform.position;
        Vector3 asteroidePosition = rb.transform.position;

        Vector3 dir = (shipPosition - asteroidePosition).normalized;
        Vector3 pos = this.CC.radius * (dir * offset);

        //Debug.Log(this.CC.radius);
        return pos+asteroidePosition;

        //float rand = Random.Range(195,);

        //return asteroidePosition + new Vector3(0,0,195);
    }

   

        public void ResourceDrop()
        {
        asteroideSource.clip = dropSound;
        asteroideSource.Play();
        Instantiate(Collectable, CalculatedPosition(), Quaternion.identity);

         }

    private void OnCollisionEnter(Collision other)   //detect collision
    {
        
        if (other.gameObject.CompareTag("Bullet1"))   //detect if tag on collided object is "Bullet"
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
                ResourceDrop();
            }   

            if (AsteroidHealth == 2)
            {
                ResourceDrop();
            }

            if (AsteroidHealth < 1)
            {
                ResourceDrop();
                Destroy(gameObject);
                
            }
        }

        if ( other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))   //detect if tag on collided object is either "Player1" or "Player2"
        {
            //Physics.IgnoreCollision() skal bruge transform og sættes i void start
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
