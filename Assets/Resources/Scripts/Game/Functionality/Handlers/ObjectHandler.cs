using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler
{
    readonly HashSet<GameObject> gameObjects = new HashSet<GameObject>();
    public ControlHandler controlHandler;
    public ResourceLoader resource;

    public ObjectHandler(ControlHandler controlHandler, ResourceLoader resource)
    {
        this.controlHandler = controlHandler;
        this.resource = resource;
    }

    public GameObject createObject(string objectTypeName, Vector3 creationPosition, float height, bool controlled)
    {
        GameObject initializedObject = MonoBehaviour.Instantiate(resource.getObjectPrefab(objectTypeName), creationPosition, Quaternion.identity);
        initializedObject.GetComponent<Stats>().height = height;
        gameObjects.Add(initializedObject);
        return initializedObject;
    }
    public GameObject createObject(string objectTypeName, Vector3 creationPosition, float height)
    {
        GameObject initializedObject = MonoBehaviour.Instantiate(resource.getObjectPrefab(objectTypeName), creationPosition, Quaternion.identity);
        initializedObject.GetComponent<Stats>().height = height;
        gameObjects.Add(initializedObject);
        return initializedObject;
    }
    public GameObject createObject(string objectTypeName, Vector3 creationPosition, bool controlled)
    {
        GameObject initializedObject = MonoBehaviour.Instantiate(resource.getObjectPrefab(objectTypeName), creationPosition, Quaternion.identity);
        if (controlled) { controlHandler.addObject(initializedObject); }
        gameObjects.Add(initializedObject);
        return initializedObject;
    }
    public GameObject createObject(string objectTypeName, Vector3 creationPosition)
    {
        GameObject initializedObject = MonoBehaviour.Instantiate(resource.getObjectPrefab(objectTypeName), creationPosition, Quaternion.identity);
        gameObjects.Add(initializedObject);
        return initializedObject;
    }

    public void destroyObject(GameObject o)
    {
        controlHandler.removeObject(o);
        gameObjects.Remove(o);
        Object.Destroy(o);
        o = null;
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

    public GameObject getGameObject(GameObject o)
    {
        foreach (GameObject go in gameObjects)
            if (go.Equals(o))
                return go;
        return null;
    }

    public HashSet<GameObject> getGameObjects()
    {
        foreach (GameObject o in gameObjects)
        {
            if (o == null)
            {
                destroyObject(o);
            }
        }
        return gameObjects;
    }
}
