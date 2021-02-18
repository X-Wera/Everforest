using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMasterControlProgram : MonoBehaviour
{
    public GameObject ResourceObject;

    private void Start()
    {
        //Debug.Log("Application started");
    }

    private void OnApplicationQuit()
    {
        //Debug.Log("Application ending after " + Time.time + " seconds");
    }
}
