using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class KeyHandler

{
    // HotKeys
    bool alt = false, capsLock = false, command = false, control = false, shift = false;

    // Holds all currently pressed keys
    HashSet<KeyCode> keysPressed = new HashSet<KeyCode>();

    // Holds all keys that have been pressed in order of when they were received.
    Stack<KeyCode> pressedStack = new Stack<KeyCode>();

    public void keyAction(Event e)
    {
        checkHotKeys(e);

        EventType keyposition = e.type;
        KeyCode key = e.keyCode;

        if (!key.Equals(KeyCode.None))
        {
            if (keyposition.Equals(EventType.KeyDown))
            {
                try
                {
                    keysPressed.Add(key);
                    pressedStack.Push(key);
                }
                catch
                {
                    //ignore
                }
            }
            if (keyposition.Equals(EventType.KeyUp))
            {
                keysPressed.Remove(key);
            }
        }
    }



    void checkHotKeys(Event e)
    {
        alt = e.alt;
        capsLock = e.capsLock;
        command = e.command;
        control = e.control;
        shift = e.shift;
    }

    public Stack<KeyCode> getStackedKeys()
    {
        return pressedStack;
    }

    public HashSet<KeyCode> getPressedkeys()
    {
        return keysPressed;
    }
}

/*
public void clearPressedQueue()
{
    pressedQueue.Clear();
}

public string lastOfQueue()
{
    return pressedQueue.Peek();
}

public void dequeue()
{
    pressedQueue.Dequeue();
}

public int itemsInQueue()
{
    return pressedQueue.Count;
}

public void removeDuplicatesFromQueue()
{
    pressedQueue = new Queue<string>(pressedQueue.Distinct());
}

public void removeSpecificElementFromQueue(string specificElementToBeRemovedFromQueue)
{
    pressedQueue = new Queue<string>(pressedQueue.Where(x => x != specificElementToBeRemovedFromQueue));
}
*/

