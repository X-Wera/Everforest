using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CURRENTLY ONLY HANDLES KEY AND MOUSE ACTIONS NO TOUCH, JOYSTICK, ETC...

public class InputHandler : MonoBehaviour
{
    ControlHandler controlHandler;
    MouseHandler mh = new MouseHandler();
    KeyHandler kh = new KeyHandler();
    KeyActionBinding kab = new KeyActionBinding();
    InputActuator inputActuator = new InputActuator();

    void Start()
    {
        // WASD
        kab.bindKeyAction(KeyCode.W, Action.MoveUp);
        kab.bindKeyAction(KeyCode.D, Action.MoveRight);
        kab.bindKeyAction(KeyCode.S, Action.MoveDown);
        kab.bindKeyAction(KeyCode.A, Action.MoveLeft);

        // ARROW KEYS
        kab.bindKeyAction(KeyCode.UpArrow, Action.MoveUp);
        kab.bindKeyAction(KeyCode.RightArrow, Action.MoveRight);
        kab.bindKeyAction(KeyCode.DownArrow, Action.MoveDown);
        kab.bindKeyAction(KeyCode.LeftArrow, Action.MoveLeft);
    }

    void Update()
    {
        Queue<Tuple<Vector3, HashSet<int>>> mouseQ = mh.getQueuedMouseClicks();
        HashSet<int> mouseButtonsPressed = mh.getMouseButtonsPressed();
        Queue<KeyCode> keyQ = kh.getQueuedKeys();
        HashSet<KeyCode> keysPressed = kh.getPressedkeys();
        inputActuator.acceptInput(keyQ, mouseQ, keysPressed, mouseButtonsPressed, kab, controlHandler);
        mouseQ.Clear();
        keyQ.Clear();


    }

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

    public void addControlHandler(ControlHandler c)
    {
        controlHandler = c;
    }
}