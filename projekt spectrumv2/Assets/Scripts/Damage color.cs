using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damagecolor : MonoBehaviour
{
    //Material shipMaterial;
    Renderer shipRenderer; 
    public float playerNumber;
    public float bulletNumber;
    Color colorOff = Color.white;
    Color colorOn = Color.red;
    public float duration = 1f;
    private bool hit = false;
    
    void Start()
    {
        shipRenderer = this.GetComponent<Renderer>();
        //shipMaterial = GetComponent<Renderer>().material;
        //shipRenderer = GetComponent<Renderer>(); 
    }

    private void Update()
    {
        //shipRenderer = GameObject.FindWithTag("Player" + playerNumber).GetComponent<Renderer>();

        if (hit == true) {
            StartCoroutine(DMGIndicator(duration)); 
            //shipRenderer.material.SetColor("_Base_Color", colorOn); 
        }
               
    }

    IEnumerator DMGIndicator(float duration)
    {
        var end = Time.time + duration;
        float start = Time.time;
        hit = false;
        Material[] mats = shipRenderer.materials;

        while(Time.time < end) {
            //shipMaterial.color = Color.Lerp(colorOff, colorOn, Mathf.Sin((Time.time - start) * 6.28f - 1.57f) * 0.5f + 0.5f); // PingPong
            float t = Mathf.Sin((Time.time - start) * 6.28f - 1.57f) * 0.5f + 0.5f;
            for (int i = 0; i < mats.Length; i++) {
                mats[i].SetFloat("_Blend_Alpha", t); 
            }
            yield return null; // Go again (while loop)
        } 
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Bullet"+bulletNumber))
        {
            hit = true;
        }
    }
}