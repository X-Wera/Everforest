using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseHandler

{
    HashSet<string> mouseButtonsPressed = new HashSet<string>();
    Queue<Tuple<Vector3, HashSet<string>>> mouseActions = new Queue<Tuple<Vector3, HashSet<string>>>();


    public void mouseAction(Event e)
    {

        GameObject.Find("LastClick").transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (e.type.ToString().Equals("mouseUp"))
        {
            mouseButtonsPressed.Remove(e.button.ToString());
        }
        if (e.type.ToString().Equals("mouseDown"))
        {
            mouseButtonsPressed.Add(e.button.ToString());
            mouseActions.Enqueue(new Tuple<Vector3, HashSet<string>>(Input.mousePosition, mouseButtonsPressed));
        }

    }

    public Queue<Tuple<Vector3, HashSet<string>>> getQueuedMouseClicks()
    {
        return mouseActions;
    }
}

