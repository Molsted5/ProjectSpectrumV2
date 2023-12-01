using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{   
    /*private GameObject player1;       First attempt before merging objects
    private GameObject player2;
    private GameObject Asteroid;
    private GameObject PickUp;
    private GameObject Factory1;
    private GameObject Factory2;*/


    private int StageCount = 1;
    private GameObject PlayerComponent;
    private GameObject ControlsComponent;
    private GameObject ShootComponent;
    private GameObject ObjectiveComponent;



    // Start is called before the first frame update
    void Start()
    {
        /*player1 = GameObject.Find("T_Player1");      First attempt before merging obejcts
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
        Factory2.SetActive(false);*/

        PlayerComponent = GameObject.Find("Players");
        PlayerComponent.SetActive(false);
        ControlsComponent = GameObject.Find("Control_Intro");
        ControlsComponent.SetActive(false);
        ShootComponent = GameObject.Find("Shoot_Intro");
        ShootComponent.SetActive(false);
        ObjectiveComponent = GameObject.Find("Objective_Intro");
        ObjectiveComponent.SetActive(false);
        
       

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {           
            switch (StageCount)
            {
                case 1:
                    PlayerComponent.SetActive(true);
                    StageCount++;
                    break;
                case 2:
                    ControlsComponent.SetActive(true);
                    StageCount++;
                    break;
                case 3:
                    ControlsComponent.SetActive(false);
                    ShootComponent.SetActive(true);
                    StageCount++;
                    break;
                case 4:
                    ShootComponent.SetActive(false);
                    ObjectiveComponent.SetActive(true);
                    StageCount++;
                    break;
                case 5:
                    ObjectiveComponent.SetActive(false);
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
