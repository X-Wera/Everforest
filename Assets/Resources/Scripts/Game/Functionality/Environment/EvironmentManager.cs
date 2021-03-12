using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager
{
    private ObjectHandler objectHandler;
    private GameObject mainCameraObject;

    public EnvironmentManager(ObjectHandler objectHandler, GameObject mainCameraObject)
    {
        this.objectHandler = objectHandler;
        this.mainCameraObject = mainCameraObject;
    }
    public void initializeEnvironment()
    {
        initializePlayer();
        createHome();
    }

    private void createHome()
    {
        objectHandler.createObject("Shop", new Vector3(-1f, -1f, 0));
        objectHandler.createObject("Rat", new Vector3(1f, 0, 0));
    }

    private void initializePlayer()
    {
        GameObject obj = objectHandler.createObject("MainCharacter", new Vector3(0, 0, 0), true, 0);
        mainCameraObject.GetComponent<CameraScript>().currenltyFocusedObject = obj;
    }
}
