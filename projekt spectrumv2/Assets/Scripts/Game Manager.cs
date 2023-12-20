using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int respawnTime = 5;
    [HideInInspector] public bool canSpawn;
    VirusSpawner spawn;
    CameraControl camControl;
    public int virusCount;
    public int recourceCount;
    public int depositCount;
    public int hackedFactories;
    [HideInInspector] public bool isGameLoaded;
    private Transform player1Transform; 
    private Transform player2Transform;
    private Transform winner;
    public int deathcountP1;
    public int deathcountP2;
    public Transform SpawnP1;
    public Transform SpawnP2;
    public GameObject Player1;
    public GameObject Player2;
    public bool isTargetFound; 
    public bool isTarget2Found; 
    public Transform shipTransform;
    bool shouldRun;

    public enum Gamestate { 
       
        titlecard,
        menu,
        turorial,
        gameActive,
        winner,
    }

    public Gamestate gamestate;
    public Gamestate previusGamestate;

    public void Winner(Transform winner) {

        camControl.m_Targets[0] = winner;
        camControl.m_Targets[1] = winner;

        // ui ellemtner, + reset button
        //zoom p� vinder selv fjender ikke er d�d
    }

    public void Awake()
    {
        
        gamestate = Gamestate.gameActive;
        //gamestate = Gamestate.titlecard;
        // titlecard
    }
    void Start(){
        isGameLoaded = false;
        shouldRun = false;
    }

public IEnumerator TimerRespawn(GameObject Player, float time) {
        if (!shouldRun) {
            yield break;
        }
        yield return new WaitForSeconds(time);
        Player.SetActive(false);
        Player.SetActive(true);
        shouldRun = false;
    }

    public void RespawnPlayer(GameObject Player, Transform Spawn) {
        
        Player.transform.position = Spawn.position;
        shouldRun = true;
        StartCoroutine(TimerRespawn(Player, 0.05f)); 
        //Player.SetActive(false);
        //Player.SetActive(true);
        
    }

    public void SpawnPlayer(GameObject Player, Transform Spawn) {

        Instantiate((Player), (Spawn.position), Quaternion.identity);
        if (Player.CompareTag("Player1")) {
            //shipTransform = GameObject.Find("Player1").GetComponent<Rigidbody>().transform;
            camControl.FindTargets(1);
        }
        if (Player.CompareTag("Player2")) {
            shipTransform = GameObject.FindWithTag("Player2").GetComponent<Rigidbody>().transform;
            camControl.FindTargets(2);
        } 
    }
    
    private void OnActiveGameLoad()
    {
        canSpawn = true;
        isGameLoaded = true;
        isTargetFound = false;
        isTarget2Found = false;
        spawn = gameObject.GetComponent<VirusSpawner>();
        camControl = GameObject.Find("Camerarig").GetComponent<CameraControl>();
        
        SpawnP1 = GameObject.Find("SpawnP1").transform;
        SpawnP2 = GameObject.Find("SpawnP2").transform;
        
        SpawnPlayer(Player1, SpawnP1); 
        SpawnPlayer(Player2, SpawnP2);
        
        player1Transform = GameObject.FindWithTag("Player1").transform;
        player2Transform = GameObject.FindWithTag("Player2").transform;
          
        virusCount = 0;
        recourceCount = 0;
        depositCount = 0;
        hackedFactories = 0;
    }

    void Update() {
        //Debug.Log(gamestate);
        if(gamestate == Gamestate.gameActive) {

            if (depositCount == 10 || deathcountP1 == 3) {
                winner = player2Transform;
                gamestate = Gamestate.winner;
            }
            else if (hackedFactories == 2 || deathcountP2 == 3) {
                winner = player1Transform;
                gamestate = Gamestate.winner;
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
            case Gamestate.winner:
                Winner(winner);
                break;
        }

        //gamestate logik for skift

        //gameste skift handlinger


        // �ndring af v�rdiger
    }





}
