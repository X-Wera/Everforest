using UnityEngine;
using System.Collections.Generic;

public class ControlHandler
{
    private readonly HashSet<GameObject> currentlyControlled = new HashSet<GameObject>();

    public void addObject(GameObject o)
    {
        if (o.GetComponent<Rigidbody2D>() == null || o.GetComponent<EverForestObject>() == null)
        {
            Debug.LogError(o + ": Was not set Controlled. A controlled object requires both a Rigidbody2d. And an EverForestObject Script (Or a script that inherents EverForest Object)" + this);
            return;
        }
        currentlyControlled.Add(o);
    }

    public void removeObject(GameObject o)
    {
        currentlyControlled.Remove(o);
    }

    public HashSet<GameObject> getControlledObjects()
    {
        return currentlyControlled;
    }
}
