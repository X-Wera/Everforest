using UnityEngine;
using System.Collections.Generic;

public class ControlHandler
{
    private readonly HashSet<GameObject> currentlyControlled = new HashSet<GameObject>();

    public void addObject(GameObject o)
    {
        if (o.GetComponent<Rigidbody2D>() == null || o.GetComponent<Stats>() == null)
        {
            Debug.LogError(o +": Was not set Controlled. A controlled object requires both a Rigidbody2D & StatsHolder component to move. " + this);
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
