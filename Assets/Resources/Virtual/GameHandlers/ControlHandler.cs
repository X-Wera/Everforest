using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHandler : MonoBehaviour
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
