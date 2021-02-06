using System;
using System.Collections.Generic;
using UnityEngine;

public class InputActuator
{

    public void acceptInput(Queue<KeyCode> keyQ, Queue<Tuple<Vector3, HashSet<string>>> mouseQ, HashSet<KeyCode> keysPressed, KeyActionBinding kab, ControlHandler controlHandler)
    {
        HashSet<Action> attemptedActions = new HashSet<Action>();
        HashSet<Action> pressedActions = new HashSet<Action>();

        // Figure out what the hell the user is doing.
        foreach (KeyCode key in keyQ)
        {
            attemptedActions.Add(kab.getBoundAction(key));
        }
        foreach (KeyCode key in keysPressed)
        {
            pressedActions.Add(kab.getBoundAction(key));
        }

        //Action Logic
        foreach (GameObject o in controlHandler.getControlledObjects())
        {
            new KeyMove(o,pressedActions);
        }
        
    }
}
