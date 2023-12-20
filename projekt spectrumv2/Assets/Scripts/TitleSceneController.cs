using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { // start game
            SceneManager.LoadScene(2); 
        }
        if (Input.GetKeyDown(KeyCode.Return)) { // start tut
            SceneManager.LoadScene(1);
        }
    }
}
