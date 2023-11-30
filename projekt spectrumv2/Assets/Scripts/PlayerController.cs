using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float playerNumber = 1f;
    public float targetSpeed = 70f;
    public float initialSpeed = 120f;
    public float angularSpeedDefault = 240f;
    public float angularDampingDefault = 20f;
    public float maxDriftSpeed = 0.8f;
    public float t = 0.2f;
    public float t2 = 1f;
    public float p = 1f;
    public float p2 = 1f;
    public float boostScale = 1.5f;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    float MoveInputValue( float playerNumber ) {    // [-1;1] back/forward input
        return Input.GetAxis( "Vertical" + playerNumber ); 
    }

    float AngularInputValue( float playerNumber ) { // [-1;1] left/right input
        return Input.GetAxis( "Horizontal" + playerNumber );
    }

    float LocalForwardSign() {  // forward = 1 and backward = -1
        return Mathf.Sign( MoveInputValue( playerNumber ) ); 
    }

    float MovementSpeed( float initialSpeed, float targetSpeed, Rigidbody rb, float p ) {
        float alphaMovementSpeed = Mathf.Clamp( Mathf.Pow( rb.velocity.magnitude / targetSpeed, p ), 0, 1 );
        return Mathf.Lerp( initialSpeed, targetSpeed, alphaMovementSpeed );
    }

    float AngularSpeed( float angularSpeedDefault, float angularDampingDefault, float targetSpeed, Rigidbody rb, float t, float t2, float p2 ) {
        float alphaAngularSpeed = Mathf.Clamp(Mathf.Pow(Mathf.InverseLerp(t, t2, rb.velocity.magnitude / targetSpeed), p2), 0, 1); // value-line stretched
        return Mathf.Lerp(angularSpeedDefault, angularDampingDefault, alphaAngularSpeed); // angularSpeed dependent on current speed
    }

    float DriftCompensation( float maxDriftSpeed, Rigidbody rb ) { // drift compensation to not loose controll, when turning
        float driftCompensation;
        if ( Mathf.Sign( AngularInputValue( playerNumber ) ) * LocalForwardSign() == Mathf.Sign( rb.angularVelocity.y ) ) // checks if input matches direction
        {
            driftCompensation = 1; // nothing changes
        }
        else {
            float alphaDrift = Mathf.Clamp( rb.angularVelocity.magnitude / maxDriftSpeed, 0, 1 );
            driftCompensation = Mathf.Lerp( 1, 2, alphaDrift );
        }
        return driftCompensation; 
    }

    float MovementBoost( float boostScale, float playerNumber ) {
        float res;
        if( Input.GetButton( "Boost" + playerNumber ) ) {
            res = boostScale;
        }
        else {
            res = 1f;
        }
        return res;
    }

    void FixedUpdate()
    {
        // add forces to move

        rb.AddRelativeForce( Vector3.forward * MoveInputValue( playerNumber ) * MovementSpeed( initialSpeed, targetSpeed, rb, p ) * MovementBoost( boostScale, playerNumber ) );

        rb.AddRelativeTorque( Vector3.up * AngularInputValue( playerNumber ) * AngularSpeed( angularSpeedDefault, angularDampingDefault, targetSpeed, rb, t, t2, p2 ) * DriftCompensation( maxDriftSpeed, rb ) * LocalForwardSign() );

        //Debug.Log(rb.angularVelocity.magnitude);
        //Debug.Log(driftCompensation);
        Debug.Log(rb.velocity.magnitude); 
    }

}