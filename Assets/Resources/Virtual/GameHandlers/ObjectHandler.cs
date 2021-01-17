using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{
    HashSet<GameObject> GameObjects = new HashSet<GameObject>();
    public ControlHandler controlHandler;
    public ResourceLoader resource;

    public void createObject(string s, Vector3 v, bool controlled)
    {
        GameObject o = resource.getObject(s);
        Instantiate(o, v, Quaternion.identity);
        GameObjects.Add(o);
        if (controlled)
        {
            controlHandler.addObject(o);
        }
    }

    public void destroyObject(GameObject o)
    {
        controlHandler.removeObject(o);
        GameObjects.Remove(o);
        Destroy(o);
    }

    public void setControlled(GameObject o, bool c)
    {
        if (c)
        {
            controlHandler.addObject(o);
        } else if (!c)
        {
            controlHandler.removeObject(o);
        }
    }
}
