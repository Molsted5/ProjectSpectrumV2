using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public int rotationX =2;
    public int rotationY = 1;
    public int rotationZ =1;

    
    void Update()
    {
        transform.Rotate(new Vector3(rotationX, rotationY, rotationZ));
    }
}
