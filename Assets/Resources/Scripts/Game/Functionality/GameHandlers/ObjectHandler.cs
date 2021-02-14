using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler
{
    HashSet<GameObject> GameObjects = new HashSet<GameObject>();
    public ControlHandler controlHandler;
    public ResourceLoader resource;

    public ObjectHandler(ControlHandler controlHandler, ResourceLoader resource)
    {
        this.controlHandler = controlHandler;
        this.resource = resource;
    }


    public GameObject createObject(string objectTypeName, Vector3 creationPosition, bool controlled)
    {
        GameObject initializedObject = MonoBehaviour.Instantiate(resource.getObjectPrefab(objectTypeName), creationPosition, Quaternion.identity);
        GameObjects.Add(initializedObject);
        if (controlled)
            controlHandler.addObject(initializedObject);
        return initializedObject;
    }

    public GameObject createObject(string objectTypeName, Vector3 creationPosition)
    {
        GameObject initializedObject = MonoBehaviour.Instantiate(resource.getObjectPrefab(objectTypeName), creationPosition, Quaternion.identity);
        GameObjects.Add(initializedObject);
        return initializedObject;
    }

    public void destroyObject(GameObject o)
    {
        controlHandler.removeObject(o);
        GameObjects.Remove(o);
        MonoBehaviour.Destroy(o);
    }

    public void setControlled(GameObject o, bool c)
    {
        if (c)
            controlHandler.addObject(o);
        else
            controlHandler.removeObject(o);
    }

    public void setControlled(GameObject o)
    {
        controlHandler.addObject(o);
    }

    public HashSet<GameObject> getGameObjects()
    {
        return GameObjects;
    }
}
