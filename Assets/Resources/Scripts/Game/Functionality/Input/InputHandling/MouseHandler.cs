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

        if (e.type.Equals(EventType.MouseDown))
        {
            mouseButtonsPressed.Add(e.button);
        }

        if (mouseButtonsPressed.Contains(0) || mouseButtonsPressed.Contains(1) || mouseButtonsPressed.Contains(2))
        {
            mouseActions.Enqueue(new Tuple<Vector3, HashSet<int>>(Input.mousePosition, mouseButtonsPressed));
            if (e.button.Equals(0))
            {
                GameObject.Find("LastClick").transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (e.type.Equals(EventType.MouseUp))
        {
            mouseButtonsPressed.Remove(e.button);
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

