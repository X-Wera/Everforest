using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// CURRENTLY ONLY HANDLES KEY AND MOUSE ACTIONS
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
    }

    // KEYSPRESSED ACTIONS
    public HashSet<string> getKeysPressed()
    {
        return kh.getKeysPressed();
    }

    public bool getLeftClicked()
    {
        return mh.getLeftClicked();
    }
}