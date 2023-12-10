using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.Burst.CompilerServices;
using UnityEngine.UI;

public class RingZone : MonoBehaviour {
    public int ringNumber;
    public int currentRingNumber;
    Material ring;
    Material barHacking;
    Material barHacking2;
    TextMeshPro tmp;
    TextMeshPro tmp2;
    //TextMeshPro tmp;
    GameManager gameManager;

    public float depositRate;
    public float hackSteps;
    public float hackRate;
    public float hackCompleted = 10f;
    public bool isCromprimised;
    public bool shouldHackingCoroutineRun;
    public bool hasHackingCoroutineStarted;
    public bool shouldDepositingCoroutineRun;
    public bool hasDepositingCoroutineStarted;

    public AudioSource factorySource;
    public AudioClip depositClip;
    public AudioClip factoryHackedClip;
    public AudioClip isComprimisedClip;

    public enum State { // diferent states the zone can be in
        None,
        Hacking,
        Hacked,
        Depositing,
        Intercepting,
    }

    public State state; // to use switch instead of endless if statements

    private State previousState;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player1")) {       // if player1 enters
            currentRingNumber = this.ringNumber;
            if (state == State.None) {   // if no state, then start hacking
                previousState = state;                      // save previous state 
                state = State.Hacking;
                shouldHackingCoroutineRun = true;
                if (!hasHackingCoroutineStarted) {
                    hasHackingCoroutineStarted = true;
                    StartCoroutine(Hacking(hackRate));
                }
            }
            else {                                          // else intercept the other players depositing
                if (state == State.Depositing) {
                    previousState = state;
                    state = State.Intercepting;
                    shouldDepositingCoroutineRun = false;
                    //StopCoroutine(Deposeting(depositRate));
                }
            }
        }
        else {                                              // player1 did not enter.
            if (other.gameObject.CompareTag("Player2")) {   // now if player2 enters
                if (state == State.None) {                  // if no state, then start depositing
                    previousState = state;
                    state = State.Depositing;
                    shouldDepositingCoroutineRun = true;
                    if (!hasDepositingCoroutineStarted) {
                        hasDepositingCoroutineStarted = true;
                        StartCoroutine(Deposeting(depositRate));
                    } 
                }
                else {                                      // else intercept the other players hacking
                    if (state == State.Hacking) {
                        previousState = state;
                        state = State.Intercepting;
                        shouldHackingCoroutineRun = false;
                        //StopCoroutine(Hacking(hackRate));
                    }
                }
            }
        }
    }

    public void OnTriggerExit(Collider other) {            // Similiar logic to OnTriggerEnter 
        if (other.gameObject.CompareTag("Player1")) {
            if (state == State.Hacking) { 
                previousState = state;
                state = State.None;
                shouldHackingCoroutineRun = false;
                //StopCoroutine(Hacking(hackRate)); 
            }
            else {
                if (state == State.Intercepting) {
                    previousState = state;
                    state = State.Depositing;
                    StartCoroutine(Deposeting(depositRate)); 
                }
            }
        }
        else {
            if (other.gameObject.CompareTag("Player2")) {
                if (state == State.Depositing) {
                    previousState = state;
                    state = State.None;
                    StopCoroutine(Deposeting(depositRate)); 
                }
                else {
                    if (state == State.Intercepting) {
                        previousState = state;
                        state = State.Hacking;
                        shouldHackingCoroutineRun = true;
                        if (!hasHackingCoroutineStarted) {
                            hasHackingCoroutineStarted = true;
                            StartCoroutine(Hacking(hackRate));
                        } 
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        depositRate = 2f;
        hackRate = 1f;
        hackSteps = 0f;
        isCromprimised = false;
        shouldHackingCoroutineRun = false;
        hasHackingCoroutineStarted = false;
        shouldDepositingCoroutineRun = false;
        hasDepositingCoroutineStarted = false;

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        barHacking = GameObject.Find("HackingBar_Image").GetComponent<Image>().material;
        barHacking2 = GameObject.Find("HackingBar_Image2").GetComponent<Image>().material;


        barHacking.SetFloat("_VisibilityAlpha", 0.0f);
        barHacking.SetFloat("_FillAmount", 0.0f);
        barHacking2.SetFloat("_VisibilityAlpha", 0.0f);
        barHacking2.SetFloat("_FillAmount", 0.0f);

        ring = GetComponent<Renderer>().material;

        tmp = GameObject.Find("HackingBar_Text").GetComponent<TextMeshPro>();
        tmp2 = GameObject.Find("HackingBar_Text2").GetComponent<TextMeshPro>(); 
        //GameObject child = transform.GetChild(0).gameObject;    // get the hacking bar, which is a child of the ring
        //barHacking = child.GetComponent<Renderer>().material;

        //GameObject child1 = transform.GetChild(1).gameObject;   // get the text 
        //tmp = child1.GetComponent<TextMeshPro>(); 

        state = State.None;
        previousState = State.None; 
    }

    public IEnumerator Deposeting(float depositRate) {
        if (!shouldDepositingCoroutineRun) {
            yield break;
        }
        while (true) {
            yield return new WaitForSeconds(depositRate);
            if (gameManager.recourceCount > 0 && state == State.Depositing) {
                gameManager.recourceCount--;
                factorySource.clip = depositClip;
                factorySource.Play();
                gameManager.depositCount++;
            }
        }
    }

    public IEnumerator Hacking(float hackRate){
        if (!shouldHackingCoroutineRun) {
            yield break; 
        }
        while (true){
            yield return new WaitForSeconds(hackRate);
            if ((gameManager.virusCount == 1 || isCromprimised) && state == State.Hacking) {
                isCromprimised = true;
                if (hackSteps == 1) { 
                gameManager.virusCount--;
                    
                }
                hackSteps++;
                barHacking.SetFloat("_FillAmount", hackSteps / 10f);
                barHacking2.SetFloat("_FillAmount", hackSteps / 10f);
                factorySource.clip = isComprimisedClip;
                factorySource.Play();
                if ( hackSteps == 10) {
                    factorySource.clip = factoryHackedClip;
                    factorySource.Play();
                    gameManager.hackedFactories++;
                    previousState = state;
                    state = State.Hacked;
                }
            }
        }  
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(currentRingNumber);
        switch (state) { // 0 hacking, 0.5 uncontested and 1 depositing
            case State.None:
                ring.SetFloat("_ColorAlpha", 0.5f);             // ring
                ring.SetFloat("_VisibilityAlpha", 1.0f);
                ring.SetFloat("_Strength", 2.0f);
                if (currentRingNumber == 1) {
                    barHacking.SetFloat("_BarVisibility", 0.0f);    // bar
                    tmp.text = "";                                  // text
                }
                
                else if (currentRingNumber == 2) {
                    barHacking2.SetFloat("_BarVisibility", 0.0f);
                    tmp2.text = "";   
                }
                break;
            case State.Hacking:
                if(gameManager.virusCount == 1 || isCromprimised) {
                    ring.SetFloat("_ColorAlpha", 0.0f);
                    ring.SetFloat("_VisibilityAlpha", 1.0f);
                    ring.SetFloat("_Strength", 7.0f);
                    if (currentRingNumber == 1) {
                        barHacking.SetFloat("_BarVisibility", 0.22f);
                        barHacking.SetFloat("_ColorSwitch", 1.0f);
                        tmp.text = "Hacking..";
                        tmp.color = new Color(0.08235288f, 0.4705881f, 0.2549019f, 1.0f);   
                    }
                    else if (currentRingNumber == 2) {
                        barHacking2.SetFloat("_BarVisibility", 0.22f);
                        barHacking2.SetFloat("_ColorSwitch", 1.0f);
                        tmp2.text = "Hacking..";
                        tmp2.color = new Color(0.08235288f, 0.4705881f, 0.2549019f, 1.0f);   
                    }
                }
                break;
            case State.Hacked:
                ring.SetFloat("_VisibilityAlpha", 0.0f);
                if (currentRingNumber == 1) {
                    barHacking.SetFloat("_BarVisibility", 0.0f);
                    tmp.text = "";
                }
                else if (currentRingNumber == 2) {
                    barHacking2.SetFloat("_BarVisibility", 0.0f);
                    tmp2.text = "";
                }
                break;
            case State.Depositing:
                if(gameManager.recourceCount > 0) {
                    ring.SetFloat("_ColorAlpha", 1.0f);
                    ring.SetFloat("_VisibilityAlpha", 1.0f);
                    ring.SetFloat("_Strength", 9.0f);
                    if (currentRingNumber == 1) {
                        barHacking.SetFloat("_BarVisibility", 0.0f);
                        //tmp.color = Color.magenta;
                    }
                    else if (currentRingNumber == 2) {
                        barHacking2.SetFloat("_BarVisibility", 0.0f);
                        //tmp2.color = Color.magenta;
                    }
                }
                break;
            case State.Intercepting:
                ring.SetFloat("_ColorAlpha", 0.5f);             
                ring.SetFloat("_VisibilityAlpha", 0.15f);
                ring.SetFloat("_Strength", 4.0f);
                barHacking.SetFloat("_BarVisibility", 0.0f);
                if (currentRingNumber == 1) {
                    if (previousState == State.Depositing) {            // intercepting depositing 
                        tmp.text = "";
                    }
                    else {                                              // intercepting hacking 
                        barHacking.SetFloat("_BarVisibility", 0.05f);
                        barHacking.SetFloat("_ColorSwitch", 1.0f);
                        tmp.text = "~no signal ";
                        tmp.color = new Color(0.08235288f, 0.4705881f, 0.2549019f, 0.05f);
                    }
                }
                if (currentRingNumber == 2) {
                    if (previousState == State.Depositing) {            // intercepting depositing 
                        tmp2.text = "";
                    }
                    else {                                              // intercepting hacking 
                        barHacking2.SetFloat("_BarVisibility", 0.05f);
                        barHacking2.SetFloat("_ColorSwitch", 1.0f);
                        tmp2.text = "~no signal ";
                        tmp2.color = new Color(0.08235288f, 0.4705881f, 0.2549019f, 0.05f);
                    }
                }
                break;
        }
    }   

}
