using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{

    private int StageCount = 1;
    private GameObject player1;
    private GameObject player2;
    private GameObject Asteroid;
    private GameObject PickUp;
    private GameObject Factory1;
    private GameObject Factory2;
   

    

    // Start is called before the first frame update
    void Start()
    {        
        player1 = GameObject.Find("T_Player1");
        player1.SetActive(false);
        player2 = GameObject.Find("T_Player2");
        player2.SetActive(false);
        Asteroid = GameObject.Find("T_Asteroid");
        Asteroid.SetActive(false);
        PickUp = GameObject.Find("T_PickUp");
        PickUp.SetActive(false);
        Factory1 = GameObject.Find("T_Factory1");
        Factory1.SetActive(false);
        Factory2 = GameObject.Find("T_Factory2");
        Factory2.SetActive(false);
        
       

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {           
            switch (StageCount)
            {
                case 1:
                    player1.SetActive(true);
                    StageCount++;
                    break;
                case 2:
                    player1.SetActive(false);
                    player2.SetActive(true);
                    StageCount++;
                    break;


            }
            /*if (StageCount == 1)
            {                
                player1.SetActive(true);
                StageCount++;
            }*/

        }

    }
}
