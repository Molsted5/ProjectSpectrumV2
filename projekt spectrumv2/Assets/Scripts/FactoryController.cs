using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour
{   
    public bool shouldDestroy;
    public void SwapFactory() {
        if (shouldDestroy) { 
            Destroy(gameObject);
        }    
        else {
            gameObject.SetActive(true);
        }
    }
}
