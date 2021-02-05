using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CURRENTLY ONLY HANDLES KEY AND MOUSE ACTIONS NO TOUCH, JOYSTICK, ETC...

public class InputHandler : MonoBehaviour
{

    MouseHandler mh = new MouseHandler();
    KeyHandler kh = new KeyHandler();

    void OnGUI()
    {
        Event e = Event.current;

        if (e.isMouse)
        {
            mh.mouseAction(e);
        }

        if (e.isKey)
        {
            kh.keyAction(e);
        }

        GameObject.Find("CursorPosition").transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public HashSet<string> getKeysPressed()
    {
        return kh.getKeysPressed();
    }

    public Queue<string> getQueuedKeys()
    {
        return kh.getQueuedKeys();
    }

    public Queue<Tuple<Vector3, HashSet<string>>> getQueuedMouseClicks()
    {
        return mh.getQueuedMouseClicks();
    }
}