using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TheMasterControlProgram : MonoBehaviour
{
    public GameObject resourceObject;
    public GameObject mainCameraObject;

    private void Start()
    {
        MonoBehaviour.Instantiate(resourceObject.GetComponent<ResourceLoader>().getObjectPrefab("MainMenu"),
            new Vector3(0, 0, 0), Quaternion.identity);
        //UnityEngine.Debug.Log("Application initialized after " + Time.realtimeSinceStartup + " seconds");
    }

    private void OnApplicationQuit()
    {
        //UnityEngine.Debug.Log("Application ending after " + Time.realtimeSinceStartup + " seconds");
    }
}
