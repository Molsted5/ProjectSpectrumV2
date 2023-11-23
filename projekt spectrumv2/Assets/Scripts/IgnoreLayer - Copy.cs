using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayer : MonoBehaviour
{
    void Start()
    {
        Physics.IgnoreLayerCollision(6, 6);
        Physics.IgnoreLayerCollision(6, 7);
    }
}