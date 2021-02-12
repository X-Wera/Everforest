using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CURRENTLY ONLY HANDLES KEY AND MOUSE ACTIONS NO TOUCH, JOYSTICK, ETC...

public class InputHandler : MonoBehaviour
{
    ControlHandler controlHandler;
    ObjectHandler objectHandler;
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
        Stack<KeyCode> keyStack = kh.getStackedKeys();
        HashSet<KeyCode> keysPressed = kh.getPressedkeys();
        if (getKab() != null && GetControlHandler() != null)
        {
            inputActuator.acceptInput(keyStack, mouseQ, keysPressed, mouseButtonsPressed, getKab(), GetControlHandler(),objectHandler);
        }
        mouseQ.Clear();
        keyStack.Clear();


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

    private KeyActionBinding getKab()
    {
        return kab;
    }

    private ControlHandler GetControlHandler()
    {
        return controlHandler;
    }

    public void addControlHandler(ControlHandler c)
    {
        controlHandler = c;
    }
    public void addObjectHandler(ObjectHandler oh)
    {
        objectHandler = oh;
    }
}