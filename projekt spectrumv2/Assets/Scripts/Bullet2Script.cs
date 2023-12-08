using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet2Script : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public float hitRadius1 = 20f;
    Rigidbody rb;
    public float minimumDMG = 15;
    public float maximumDMG = 15;

    private void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Astroide"))
        {
            Destroy(gameObject);
        }*/

        if (other.gameObject.CompareTag("Player1"))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, hitRadius1);
            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

                if (!targetRigidbody)
                    continue;

                PlayerHealth targetHealth = targetRigidbody.GetComponent<PlayerHealth>();

                if (!targetHealth) continue;

                float damage = CalculateDamage();

                targetHealth.TakeDamage(damage);
            }

            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }

        Destroy(gameObject);
    }
    private float CalculateDamage()
    {


        float damage = maximumDMG;

        return damage;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddRelativeForce(Vector3.up * speed, ForceMode.Impulse);
        Destroy(gameObject, lifetime);

    }




}
