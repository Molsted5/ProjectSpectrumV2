using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int count;
    private int maxCount = 4;
    public TMP_Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
            textComponent.text = count++.ToString();

        
    }
}
