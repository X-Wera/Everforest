using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UpdateHandler : MonoBehaviour
{
    public delegate void Tick();
    public event Tick OnTick;

    private ObjectHandler objectHandler;
    private GameObject groundObject;
    private GameObject mainCamera;

    private void Start()
    {
        objectHandler = this.gameObject.GetComponent<GameManagerScript>().getObjectHandler();
        groundObject = this.gameObject.GetComponent<GameManagerScript>().groundObject;
        mainCamera = this.gameObject.GetComponent<GameManagerScript>().mainCamera;
    }

    private void Update()
    {
        zAxisDepthAlignment();
    }

    private void FixedUpdate()
    {
        if (OnTick != null)
        {
            OnTick();
        }
    }

    private void zAxisDepthAlignment()
    {
        float farthestObjectOutDistance = mainCamera.transform.position.y;
        float closestObjectInDistance = mainCamera.transform.position.y;


        foreach (GameObject o in objectHandler.getGameObjects())
        {
            float z = o.transform.position.y;
            if (o.GetComponent<ArtificialAxis>() != null && o.GetComponent<ArtificialAxis>().get() != 0)
            {
                z += (float)o.GetComponent<ArtificialAxis>().get();
                if (z >= farthestObjectOutDistance) { farthestObjectOutDistance = z; }
                if (z <= closestObjectInDistance) { closestObjectInDistance = z; }
            }
            o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, z);

            if (z >= farthestObjectOutDistance && z <= (mainCamera.transform.position.y + mainCamera.GetComponent<Camera>().orthographicSize * 2f))
                farthestObjectOutDistance = z;

            if (z <= closestObjectInDistance && z >= (mainCamera.transform.position.y - mainCamera.GetComponent<Camera>().orthographicSize * 2f))
                closestObjectInDistance = z;

            groundObject.transform.position = new Vector3(groundObject.transform.position.x, groundObject.transform.position.y, farthestObjectOutDistance + 1);
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, closestObjectInDistance - 1);
            mainCamera.GetComponent<Camera>().farClipPlane = groundObject.transform.position.z - mainCamera.transform.position.z + 1;

        }
    }
}
