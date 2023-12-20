using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDirectionControl : MonoBehaviour
{
    private Quaternion relativeRotation; 
    public Vector3 angle = new Vector3(90f, 0f, 0f);
    public Vector3 position = new Vector3(0f, 0f, -40f);

    void Start()
    {
        //relativeRotation = transform.parent.localRotation;
        transform.rotation = Quaternion.Euler(angle);
        transform.position = transform.parent.position + position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = relativeRotation;
        transform.rotation = Quaternion.Euler(angle);
        transform.position = transform.parent.position + position;
    }
}
