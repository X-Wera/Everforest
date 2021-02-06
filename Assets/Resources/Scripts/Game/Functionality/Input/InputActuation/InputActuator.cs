using System;
using System.Collections.Generic;
using UnityEngine;

public class InputActuator
{

    public void acceptInput(Queue<KeyCode> keyQ, Queue<Tuple<Vector3, HashSet<int>>> mouseQ, HashSet<KeyCode> keysPressed, HashSet<int> mouseButtonsPressed, KeyActionBinding kab, ControlHandler controlHandler)
    {
        HashSet<Action> attemptedActions = new HashSet<Action>();
        HashSet<Action> pressedActions = new HashSet<Action>();
        HashSet<GameObject> controlledObjects = controlHandler.getControlledObjects();


        // Figure out what the hell the user is doing.
        if (!mouseButtonsPressed.Contains(0))
        {
            foreach (KeyCode key in keyQ)
            {
                attemptedActions.Add(kab.getBoundAction(key));
            }
            foreach (KeyCode key in keysPressed)
            {
                pressedActions.Add(kab.getBoundAction(key));
            }
            foreach (Tuple<Vector3, HashSet<int>> click in mouseQ)
            {

            }


            //Action Logic
            foreach (GameObject o in controlledObjects)
            {
                new KeyMove(o, pressedActions);
            }

        }
        else
        {
            foreach (GameObject o in controlledObjects)
            {
                Vector3 position = Vector3.MoveTowards(o.GetComponent<Rigidbody2D>().position, Camera.main.ScreenToWorldPoint(Input.mousePosition), o.GetComponent<StatsHolder>().getSpeed());
                o.GetComponent<Rigidbody2D>().MovePosition(position);
            }

        }

        keyQ.Clear();
        mouseQ.Clear();

    }
}
