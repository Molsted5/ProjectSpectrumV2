using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int playernumber = 1;
    public float speedDefault = 70;
    public float angularSpeedDefault = 240;
    public float angularDampingDefault = 20;
    public float maxDriftSpeed = 0.8f;
    public float t = 0.2f;
    public float t2 = 1f;
   

    Rigidbody rb;
    float moveInputValue;
    float angularInputValue;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Finds and saves the desired angular speed 
        float currentSpeed = rb.velocity.magnitude;
        float alphaAngularSpeed  = Mathf.InverseLerp(t, t2, currentSpeed / speedDefault); // value-line stretched
        float angularSpeed = Mathf.Lerp(angularSpeedDefault, angularDampingDefault, Mathf.Clamp(alphaAngularSpeed, 0, 1)); // angularSpeed dependent on current speed

        // Drift compensation to not loose controll, when turning
        float driftCompensation;

        if (Mathf.Sign(angularInputValue) == Mathf.Sign(rb.angularVelocity.y)) // checks if input matches direction
        {
            driftCompensation = 1; // Nothing changes
        }
        else
        {
            float currentAngularSpeed = rb.angularVelocity.magnitude;
            float alphaDrift = Mathf.Clamp(currentAngularSpeed / maxDriftSpeed, 0, 1);
            driftCompensation = Mathf.Lerp(1, 2, alphaDrift);
        }

        // Add forces to move
        moveInputValue = Input.GetAxis("Vertical" + playernumber); // [-1;1] back/forward input
        rb.AddRelativeForce(Vector3.forward * moveInputValue * speedDefault);

        angularInputValue = Input.GetAxis("Horizontal" + playernumber); // [-1;1] left/right input
        rb.AddRelativeTorque(Vector3.up * angularInputValue * angularSpeed * driftCompensation);

        //Debug.Log(rb.angularVelocity.magnitude);

    }
    
}