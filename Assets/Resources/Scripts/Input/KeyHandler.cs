using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class KeyHandler

{
    bool alt = false;
    bool capsLock = false;
    bool command = false;
    bool control = false;
    bool shift = false;

    // Holds all currently pressed keys
    HashSet<string> keysPressed = new HashSet<string>();

    // Holds all keys that have been pressed in order of when they were received.
    Queue<string> pressedQueue = new Queue<string>();

    public void keyAction(Event e)
    {
        checkHotKeys(e);


        string keyposition = e.type.ToString();
        string key = e.keyCode.ToString();

        if (!key.Equals("None"))
        {
            if (keyposition.Equals("KeyDown"))
            {
                try
                {
                    keysPressed.Add(key);
                    pressedQueue.Enqueue(key);
                }
                catch (ArgumentException)
                {
                    // IGNORING UNCAUGHT KEYBOARD EVENTS
                    // Console.WriteLine("Failed to add pressed key to keysPressed.");
                }
            }
            if (keyposition.Equals("KeyUp"))
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




    // KEYSPRESSED ACTIONS
    public HashSet<string> getKeysPressed()
    {
        return keysPressed;
    }

    // PRESSEDQUEUE ACTIONS
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
}
