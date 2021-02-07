using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseHandler

{
    HashSet<int> mouseButtonsPressed = new HashSet<int>();
    Queue<Tuple<Vector3, HashSet<int>>> mouseActions = new Queue<Tuple<Vector3, HashSet<int>>>();


    public void mouseAction(Event e)
    {
        if (e.type.Equals(EventType.MouseUp))
        {
            if (e.button.Equals(0))
            {
                GameObject.Find("LastClick").transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            mouseButtonsPressed.Remove(e.button);
        }
        if (e.type.Equals(EventType.MouseDown))
        {
            mouseButtonsPressed.Add(e.button);
            mouseActions.Enqueue(new Tuple<Vector3, HashSet<int>>(Input.mousePosition, mouseButtonsPressed));
        }
    }

    public Queue<Tuple<Vector3, HashSet<int>>> getQueuedMouseClicks()
    {
        return mouseActions;
    }

    public HashSet<int> getMouseButtonsPressed()
    {
        return mouseButtonsPressed;
    }
}

