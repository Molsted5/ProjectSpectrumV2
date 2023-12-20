using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
