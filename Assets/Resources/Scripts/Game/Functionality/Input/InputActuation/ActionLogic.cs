using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLogic
{
    public void SingleObjectAction(GameObject o, HashSet<Action> pressedActions, Queue<Action> attemptedActions, HashSet<int> mouseButtonsPressed, Queue<GameObject> ItemsClickedThisUpdate)
    {
        new MoveLogic(o, pressedActions, attemptedActions, mouseButtonsPressed);
    }
}
