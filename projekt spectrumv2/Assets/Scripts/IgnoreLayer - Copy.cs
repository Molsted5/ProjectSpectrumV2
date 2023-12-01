using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayer : MonoBehaviour
{

    void Start()
    {
        Physics.IgnoreLayerCollision(6, 8);
        Physics.IgnoreLayerCollision(6, 7);
        Physics.IgnoreLayerCollision(8, 7);
        Physics.IgnoreLayerCollision(8, 9); 
    }
}