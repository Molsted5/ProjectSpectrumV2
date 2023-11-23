using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroidesounds : MonoBehaviour
{

    public AudioSource impactSounds;
    public AudioClip lowImpact;
    public AudioClip bigImpact;


    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            impactSounds.clip = lowImpact;
            impactSounds.Play();
        }

        if(other.gameObject.CompareTag("Astroide"))
        {
            impactSounds.clip = bigImpact;
            impactSounds.Play();

        }

        if (other.gameObject.CompareTag("Player1"))
        {
            impactSounds.clip = bigImpact;
            impactSounds.Play();

        }

        if (other.gameObject.CompareTag("Player2"))
        {
            impactSounds.clip = bigImpact;
            impactSounds.Play();

        }


    }
}
