using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActionManagment : MonoBehaviour
{
    InputHandler inputHandler;

    // Update is called once per frame
    void Update()
    {
        if (inputHandler != null)
        {
            handleKeysPressed(inputHandler.getQueuedKeys());
            handleMouseActions(inputHandler.getQueuedMouseClicks());
        }
    }

    void handleKeysPressed(Queue<string> keysTyped)
    {
        keysTyped = new Queue<string>(keysTyped.Distinct());
        foreach (string key in keysTyped)
        {

        }
        keysTyped.Clear();
    }

    void handleMouseActions(Queue<Tuple<Vector3, HashSet<string>>> mouseClicks)
    {
        foreach (Tuple<Vector3, HashSet<string>> mouseClick in mouseClicks)
        {

        }
        mouseClicks.Clear();
    }

    public void setInputHandler(InputHandler i)
    {
        inputHandler = i;
    }
}
