using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //public int count = 0;
    private int MaxResourceCount = 4;
    private int MaxDepositCount = 10;
    public TMP_Text textComponentP1;
    public TMP_Text textComponentP2;
    GameManager gameManagerScript;

    //Objects used in script
    public GameObject Player1UIComponent;
    public GameObject Player2UIComponent;

    //Sprites
    public Sprite VirusInventoryEmpty;
    public Sprite VirusInventoryFull;

    //UI icon objects
    public GameObject VirusInventoryIcon;    
    public GameObject Player1Lives;
    public GameObject Player2Lives;
    


    // Start is called before the first frame update
    void Start()
    {          
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();        

        textComponentP1.text = gameManagerScript.recourceCount + "/" + MaxResourceCount;
        textComponentP2.text = gameManagerScript.depositCount + "/" + MaxDepositCount;
    }

    // Update is called once per frame
    void Update()
    {

        textComponentP1.text = gameManagerScript.recourceCount + "/" + MaxResourceCount;
        textComponentP2.text = gameManagerScript.depositCount + "/" + MaxDepositCount;

    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Pickup"))
        
            

        
    }
}
