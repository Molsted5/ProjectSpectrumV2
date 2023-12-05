using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int respawnTime = 5;
    public bool canSpawn;
    VirusSpawner spawn;
    CameraControl camControl;
    public int virusCount;
    public int recourceCount;
    public int depositCount;
    public int hackedFactories;
    public bool isGameLoaded;


    private enum Gamestate { 
       
        titlecard,
        menu,
        turorial,
        gameActive,
        winner,
    }

    private Gamestate gamestate;
    private Gamestate previusGamestate;

    public void Winner(int winner) {
        
        //camControl.m_Targets[0] 
        //camControl.m_Targets[1]

        // ui ellemtner, + reset button
        //zoom på vinder selv fjender ikke er død
    }

    private void Awake()
    {
        gamestate = Gamestate.gameActive;
        //gamestate = Gamestate.titlecard;
        // titlecard
    }
    void Start(){
        isGameLoaded = false;
        // sæt start værdiger, resource, virus,
        // bool, kan værdiger ændres.
        
    }

    private void OnActiveGameLoad()
    {
        spawn = gameObject.GetComponent<VirusSpawner>();
        camControl = GameObject.Find("Camerarig").GetComponent<CameraControl>();
        virusCount = 0;
        recourceCount = 0;
        depositCount = 0;
        hackedFactories = 0;
        canSpawn = true;
        isGameLoaded=true;
    }

    void Update() {

        if(gamestate == Gamestate.gameActive) {
            if (depositCount == 10)
            {
                
            }


        }




        switch (gamestate) {
            case Gamestate.titlecard:
                // load title scene
                break;
            case Gamestate.menu:
                //load menu scene
                break;
            case Gamestate.turorial:
                // load tutorial scene
                break;
            case Gamestate.gameActive:
                //load main scene
                if (!isGameLoaded) {
                    OnActiveGameLoad();
                }
                if (canSpawn) {
                    StartCoroutine(spawn.Spawn(respawnTime));
                    canSpawn = false;
                }
                break;
            case Gamestate.winner: break;
                // call winner function
                break;
        }

        //gamestate logik for skift

        //gameste skift handlinger


        // ændring af værdiger
    }





}
