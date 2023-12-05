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
    public GameObject ShipText;
    public GameObject ContinueText;
    public GameObject WelcomeText;
    public GameObject End;
    public GameObject Play;

    public GameObject Player1;
    public GameObject Player2;
    private Vector3 P1Position;
    private Quaternion P1Rotation;
    private Vector3 P2Position;
    private Quaternion P2Rotation;






    /*private GameObject TestComponent;
    private GameObject TestComponent1;*/


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
        ShipText.SetActive(false);
        //ContinueText.SetActive(false);
        End.SetActive(false);
        Play.SetActive(false);

        P1Position = Player1.transform.position;
        P1Rotation = Player1.transform.rotation;
        P2Position = Player2.transform.position;
        P2Rotation = Player2.transform.rotation;
        Player1.SetActive(false);
        Player2.SetActive(false);


        




        /*PlayerController[] playerControllers = GameObject.Find("Players").GetComponentsInChildren<PlayerController>(true);

        
        if (playerControllers.Length > 0)
        {
            foreach (PlayerController obj in playerControllers)
            {
                Debug.Log("Activating script on: " + obj.gameObject.name);
                obj.gameObject.SetActive(true);
            }
        }*/


        /*GameObject.Find("Players").GetComponentsInChildren<PlayerController>(true);       
           foreach (PlayerController obj in GameObject.Find("Players").GetComponentsInChildren<PlayerController>(true))
                {
                    obj.SetActive(true);
                }*/

        //GameObject.Find("Players").GetComponentInChildren<PlayerController>(true).enabled = true;



        /*TestComponent = GameObject.Find("Player2_Test");              First attempt at disabling scripts (don't do this lol)
        TestComponent1 = TestComponent.GetComponent(typeof(Scipt);*/

        //GameObject.Find("Player2_Tutorial").GetComponent<Damagecolor>().enabled = false;     Call and disable a component on another gameobject (scripts set to off by default in unity)


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {           
            switch (StageCount)
            {
                case 1:
                    WelcomeText.SetActive(false);
                    ShipText.SetActive(true);                    
                    Player1.SetActive(true);                    
                    Player2.SetActive(true);
                    PlayerComponent.SetActive(true);
                    StageCount++;
                    break;
                case 2:
                    ControlsComponent.SetActive(true);
                    ShipText.SetActive(false);
                    Player1.GetComponent<PlayerController>().enabled = true;
                    Player2.GetComponent<PlayerController>().enabled = true;
                    StageCount++;
                    break;
                case 3:
                    Player1.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    Player2.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    Player1.transform.SetPositionAndRotation(P1Position, P1Rotation);
                    Player2.transform.SetPositionAndRotation(P2Position, P2Rotation);
                    Player1.GetComponent<PlayerController>().enabled = false;
                    Player2.GetComponent<PlayerController>().enabled = false;
                    ControlsComponent.SetActive(false);
                    ShootComponent.SetActive(true);
                    Player1.GetComponent<player1ShootTest>().enabled = true;
                    Player2.GetComponent<player2ShootTest>().enabled = true;
                    StageCount++;
                    break;
                case 4:
                    ShootComponent.SetActive(false);
                    Player1.GetComponent<player1ShootTest>().enabled = false;
                    Player2.GetComponent<player2ShootTest>().enabled = false;
                    ObjectiveComponent.SetActive(true);
                    StageCount++;
                    break;
                case 5:
                    ObjectiveComponent.SetActive(false);
                    PlayerComponent.SetActive(false);
                    ContinueText.SetActive(false);
                    Player1.SetActive(false);
                    Player2.SetActive(false);
                    End.SetActive(true);
                    Play.SetActive(true);
                    StageCount++;
                    break;

            }
       
        }

    }
}
