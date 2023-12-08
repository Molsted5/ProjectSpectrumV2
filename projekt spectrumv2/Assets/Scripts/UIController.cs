using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using TMPro;
using OpenCover.Framework.Model;

public class Score : MonoBehaviour
{
    //Int Conuters
    public int count;
    private int MaxFactoryCount = 3;
    private int MaxDepositCount = 10;
    
    //Sprites
    public Sprite VirusInventoryEmpty;
    public Sprite VirusInventoryFull;
    public Sprite ResourceInventoryEmpty;
    public Sprite ResourceInventoryFull;

    //UI Text Objects
    public TMP_Text textComponentP1;
    public TMP_Text textComponentP2;
    public TMP_Text VictoryScreen;

    //UI icon objects
    public GameObject VirusInventoryIcon;    
    public GameObject Player1Life1;
    public GameObject Player1Life2;
    public GameObject Player1Life3;
    public GameObject Player2Life1;
    public GameObject Player2Life2;
    public GameObject Player2Life3;
    public GameObject P2UIResource1;
    public GameObject P2UIResource2;
    public GameObject P2UIResource3;
    public GameObject P2UIResource4;
    public GameObject OtherIcons;

    //Sliders
    public GameObject HackingBar;

    //Full canvases
    public GameObject UI_Canvas;
    public GameObject UI_Victory;

    //Script calls
    GameManager gameManagerScript;
    RingZone RingZoneScript;


    // Start is called before the first frame update
    void Start()
    {
        RingZoneScript = GameObject.FindWithTag("Factory").GetComponent<RingZone>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();        
        count = 1;

        textComponentP1.text = gameManagerScript.hackedFactories + "/" + MaxFactoryCount + " Hacked";
        textComponentP2.text = gameManagerScript.depositCount + "/" + MaxDepositCount + " Deposited";
        UI_Victory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        switch (gameManagerScript.virusCount) //Turn icon for virus inventory on or off
        {
            case 0:
                VirusInventoryIcon.GetComponent<UnityEngine.UI.Image>().sprite = VirusInventoryEmpty;
                count = 2;
                //Debug.Log("Empty");
                break;
            case 1:
                VirusInventoryIcon.GetComponent<UnityEngine.UI.Image>().sprite = VirusInventoryFull;
                count = 1;
                //Debug.Log("Full");
            break;
        }

    switch (gameManagerScript.recourceCount) //Switch between 1-4 full resource icons depending on resourceCount in gameManagerScript
        {
            case 0:
                P2UIResource1.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                P2UIResource2.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                P2UIResource3.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                P2UIResource4.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                break;
            case 1:
                P2UIResource1.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource2.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                P2UIResource3.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                P2UIResource4.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                break;
            case 2:
                P2UIResource1.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource2.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource3.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                P2UIResource4.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                break;
            case 3:
                P2UIResource1.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource2.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource3.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource4.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryEmpty;
                break;
            case 4:
                P2UIResource1.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource2.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource3.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                P2UIResource4.GetComponent<UnityEngine.UI.Image>().sprite = ResourceInventoryFull;
                break;
        }

        switch (gameManagerScript.deathcountP1) //Life icons for player 1 decrease as deathcountP1 increase
        {
            case 0: 
                //All 3 life icons active as default
                break;
            case 1:
                Player1Life3.SetActive(false);
                //3rd life icon deactivated
                break;
            case 2:
                Player1Life2.SetActive(false);
                //2nd life icon deactivated
                break;
            case 3:
                Player1Life1.SetActive(false);
                //1st life icon deactivated (dead sad days)
                break;
        }

        switch (gameManagerScript.deathcountP2) //Life icons for player 2 decrease as deathCountP2 increase
        {
            case 0:
                //All 3 life icons active as default
                break;
            case 1:
                Player2Life3.SetActive(false);
                //3rd life icon deactivated
                break;
            case 2:
                Player2Life2.SetActive(false);
                //2nd life icon deactivated
                break;
            case 3:
                Player2Life1.SetActive(false);
                //1st life icon deactivated
                break;
        }

        /*if (RingZoneScript.hackSteps > 0)
        {

            HackingBar.SetActive(true);
            
        }
        HackingBar.GetComponent<UnityEngine.UI.Slider>().value = RingZoneScript.hackSteps;*/

        //Text constantly updating to match Deposit Count and Hacked Factoriest
        textComponentP1.text = gameManagerScript.hackedFactories + "/" + MaxFactoryCount + " Hacked";
        textComponentP2.text = gameManagerScript.depositCount + "/" + MaxDepositCount + " Deposited";


        if (gameManagerScript.gamestate == GameManager.Gamestate.winner) //When Victory disable UI and set UI winner text
        {

            UI_Canvas.SetActive(false);
            UI_Victory.SetActive(true);

            if (gameManagerScript.depositCount == 10 || gameManagerScript.deathcountP1 == 3)
            {
                VictoryScreen.text = "Player 2 Victory!";
            }

            else if (gameManagerScript.hackedFactories == 3 || gameManagerScript.deathcountP2 == 3)
            {
                VictoryScreen.text = "Player 1 Victory!";
            }
        }        
    }
}
