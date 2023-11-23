using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RingZone : MonoBehaviour {

    Material ring;
    Material barHacking;
    TextMeshPro tmp;
    
    private enum State { // diferent states the zone can be in
        None,
        Hacking,
        Hacked,
        Depositing,
        Intercepting,
    }

    private State state; // to use switch instead of endless if statements


    private State previousState; 

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player1")) {       // if player1 enters
            if (state == State.None) {                      // if no state, then start hacking
                previousState = state;                      // save previous state 
                state = State.Hacking;                  
            }
            else {                                          // else intercept the other players depositing
                if (state == State.Depositing) {
                    previousState = state;
                    state = State.Intercepting;
                }
            }
        }
        else {                                              // player1 did not enter.
            if (other.gameObject.CompareTag("Player2")) {   // now if player2 enters
                if (state == State.None) {                  // if no state, then start depositing
                    previousState = state;
                    state = State.Depositing;
                }
                else {                                      // else intercept the other players hacking
                    if (state == State.Hacking) {
                        previousState = state;
                        state = State.Intercepting;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {            // Similiar logic to OnTriggerEnter 
        if (other.gameObject.CompareTag("Player1")) {
            if (state == State.Hacking) {
                previousState = state;
                state = State.None;
            }
            else {
                if (state == State.Intercepting) {
                    previousState = state;
                    state = State.Depositing;
                }
            }
        }
        else {
            if (other.gameObject.CompareTag("Player2")) {
                if (state == State.Depositing) {
                    previousState = state;
                    state = State.None;
                }
                else {
                    if (state == State.Intercepting) {
                        previousState = state;
                        state = State.Hacking;
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        ring = GetComponent<Renderer>().material;
        
        GameObject child = transform.GetChild(0).gameObject;    // get the hacking bar, which is a child of the ring
        barHacking = child.GetComponent<Renderer>().material;

        GameObject child1 = transform.GetChild(1).gameObject;   // get the text 
        tmp = child1.GetComponent<TextMeshPro>(); 

        state = State.None;
        previousState = State.None; 
    }

    // Update is called once per frame
    void Update() {

        switch (state) { // 0 hacking, 0.5 uncontested and 1 depositing
            case State.None:
                ring.SetFloat("_ColorAlpha", 0.5f);             // ring
                ring.SetFloat("_VisibilityAlpha", 1.0f);
                barHacking.SetFloat("_BarVisibility", 0.0f);    // bar
                tmp.text = "";                                  // text
                break;
            case State.Hacking:
                ring.SetFloat("_ColorAlpha", 0.0f);             
                ring.SetFloat("_VisibilityAlpha", 1.0f);
                barHacking.SetFloat("_BarVisibility", 1.0f);
                barHacking.SetFloat("_ColorSwitch", 1.0f);
                tmp.text = "Hacking..";
                tmp.color = new Color(0.08235288f, 0.4705881f, 0.2549019f, 1.0f);
                break;
            case State.Hacked:             
                ring.SetFloat("_VisibilityAlpha", 0.0f);
                barHacking.SetFloat("_BarVisibility", 0.0f);
                tmp.text = "";
                break;
            case State.Depositing:
                ring.SetFloat("_ColorAlpha", 1.0f);             
                ring.SetFloat("_VisibilityAlpha", 1.0f);
                barHacking.SetFloat("_BarVisibility", 0.0f);
                tmp.text = "+10";
                tmp.color = Color.magenta;
                break;
            case State.Intercepting:
                ring.SetFloat("_ColorAlpha", 0.5f);             
                ring.SetFloat("_VisibilityAlpha", 0.15f);
                if (previousState == State.Depositing) {            // intercepting depositing 
                    tmp.text = ""; 
                }
                else {                                              // intercepting hacking 
                    barHacking.SetFloat("_BarVisibility", 0.05f);
                    barHacking.SetFloat("_ColorSwitch", 1.0f);
                    tmp.text = "~no signal ";
                    tmp.color = new Color (0.08235288f, 0.4705881f, 0.2549019f, 0.05f);
                }                
                break;
        }
    }   

}
