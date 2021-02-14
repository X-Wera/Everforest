using UnityEngine;
using System.Collections.Generic;

public class ControlHandler
{
    readonly static HashSet<GameObject> currentlyControlled = new HashSet<GameObject>();

    public void addObject(GameObject o)
    {
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
