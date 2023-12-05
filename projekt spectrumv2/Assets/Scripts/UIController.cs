using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int count;
    private int maxCount = 4;
    public TMP_Text textComponent;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = count + "/" + maxCount;
        count = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (count < maxCount)
            {
                count++;
            }

            textComponent.text = count + "/" + maxCount;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Pickup"))
        
            

        
    }
}
