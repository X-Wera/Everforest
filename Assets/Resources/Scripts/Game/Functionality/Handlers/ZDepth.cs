﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZDepth : MonoBehaviour
{
    private ObjectHandler objectHandler;
    private GameObject groundObject;
    private GameObject mainCameraObject;

    float farthestObjectOutDistance;
    float closestObjectInDistance;

    private void Start()
    {
        objectHandler = this.gameObject.GetComponent<GameManagerScript>().getObjectHandler();
        groundObject = this.gameObject.GetComponent<GameManagerScript>().groundObject;
        mainCameraObject = GameObject.Find("MainCamera");
    }

    private void Update()
    {
        zAxisDepthAlignment();
    }

    private void zAxisDepthAlignment()
    {
        farthestObjectOutDistance = mainCameraObject.transform.position.y;
        closestObjectInDistance = mainCameraObject.transform.position.y;

        foreach (GameObject o in objectHandler.getGameObjects())
        {
            bindZToY(o);
            float zDepth = o.transform.position.y;

            setFurthestAndClosest(o, zDepth);
            o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, zDepth + o.GetComponent<EverForestObject>().altitude);
            trimClipping();
        }
    }

    private float bindZToY(GameObject o)
    {
        o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, o.transform.position.y);
        return o.transform.position.y;
    }

    private void setFurthestAndClosest(GameObject o, float zDepth)
    {
        if (o.transform.position.y >= mainCameraObject.transform.position.y - mainCameraObject.GetComponent<Camera>().orthographicSize && o.transform.position.y <= mainCameraObject.transform.position.y + mainCameraObject.GetComponent<Camera>().orthographicSize)
        {
            if (zDepth >= farthestObjectOutDistance)
                farthestObjectOutDistance = zDepth;

            if (zDepth <= closestObjectInDistance)
                closestObjectInDistance = zDepth;
        }
    }

    private void trimClipping()
    {
        groundObject.transform.position = new Vector3(groundObject.transform.position.x, groundObject.transform.position.y, farthestObjectOutDistance + 1);
        mainCameraObject.transform.position = new Vector3(mainCameraObject.transform.position.x, mainCameraObject.transform.position.y, closestObjectInDistance - 1);
        mainCameraObject.GetComponent<Camera>().farClipPlane = groundObject.transform.position.z - mainCameraObject.transform.position.z + 1;
    }
}
