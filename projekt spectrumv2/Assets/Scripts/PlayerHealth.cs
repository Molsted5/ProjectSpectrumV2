using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public float startingHealth = 100f;               // The amount of health each player starts with.
    GameManager gameManager;
    CameraControl camControl;

    Material healthbarMaterial;
    public float playerNumber;
    //public Slider slider;                             // The slider to represent how much health the player currently has.
    //public Image fillImage;                           // The image component of the slider.
    //public Color fullHealthColor = Color.green;       // The color the health bar will be when on full health.
    //public Color zeroHealthColor = Color.red;         // The color the health bar will be when on no health.
    //public GameObject m_ExplosionPrefab;                // A prefab that will be instantiated in Awake, then used whenever the player dies.


    //private AudioSource m_ExplosionAudio;               // The audio source to play when the player explodes.
    //private ParticleSystem m_ExplosionParticles;        // The particle system the will play when the player is eliminated.
    private float currentHealth;                      // How much health the player currently has.
    private bool dead;                                // Has the player been reduced beyond zero health yet?


    private void Awake() {
        healthbarMaterial = GameObject.Find("Healthbar"+playerNumber).GetComponent<Renderer>().material;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        camControl = gameManager.GetComponent<CameraControl>();
        // Instantiate the explosion prefab and get a reference to the particle system on it.
        //m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();

        // Get a reference to the audio source on the instantiated prefab.
        // m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        // Disable the prefab so it can be activated when it's required.
        //m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable() {
        // When the tank is enabled, reset the tank's health and whether or not it's dead.
        currentHealth = startingHealth;
        dead = false;

        // Update the health slider's value and color.
        SetHealthUI();
    }


    public void TakeDamage(float amount) {
        // Reduce current health by the amount of damage done.
        currentHealth -= amount;

        // Change the UI elements appropriately.
        SetHealthUI();

        // If the current health is at or below zero and it has not yet been registered, call OnDeath.
        if (currentHealth <= 0f && !dead) {
            OnDeath();
        }
        //Debug.Log(currentHealth); 
    }


    private void SetHealthUI() {
        healthbarMaterial.SetFloat("_HP_Fraction", currentHealth / startingHealth);

        // Set the slider's value appropriately.
        //slider.value = currentHealth;

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
        //fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);
    }


    private void OnDeath() {
        // Set the flag so that this function is only called once.
        dead = true;
        if (gameObject.CompareTag("Player1")) {
            //gameManager.isTargetFound = false;
            gameManager.deathcountP1++;
            //gameObject.SetActive(false);
            gameManager.RespawnPlayer(gameObject, gameManager.SpawnP1);
            //gameManager.SpawnPlayer(gameManager.Player1, gameManager.SpawnP1);
        }
        else {
            //gameManager.isTarget2Found = false;
            gameManager.deathcountP2++;
            //gameObject.SetActive(false);
            gameManager.RespawnPlayer(gameObject, gameManager.SpawnP2);
            //gameManager.SpawnPlayer(gameManager.Player2, gameManager.SpawnP2);
        }

        // Move the instantiated explosion prefab to the tank's position and turn it on.
        //m_ExplosionParticles.transform.position = transform.position;
        //m_ExplosionParticles.gameObject.SetActive(true);

        // Play the particle system of the tank exploding.
        //m_ExplosionParticles.Play();

        // Play the tank explosion sound effect.
        //m_ExplosionAudio.Play();
        //m_ExplosionAudio.Play();

        // Turn the tank off.

        
    }

}