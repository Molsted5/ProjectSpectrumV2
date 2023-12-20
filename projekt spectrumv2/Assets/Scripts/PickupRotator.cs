using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupRotator : MonoBehaviour
{
    public float rotationX =2;
    public float rotationY = 1;
    public float rotationZ =1;

    
    void Update()
    {
        transform.Rotate(new Vector3(rotationX, rotationY, rotationZ));
    }
}
