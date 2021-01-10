using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InputHandler : MonoBehaviour
{
    // Holds all currently pressed keys
    HashSet<string> keysPressed = new HashSet<string>();

    // Holds all keys that have been pressed in order
    Queue<string> pressedQueue = new Queue<string>();

    void Update()
    {
        if (pressedQueue.Count > 30)
        {

        }
    }

    void OnGUI()
    {

        Event e = Event.current;

        // CARSONS CRAZY KEY HANDLING CODE
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
                    //Console.WriteLine("Failed to add pressed key to keysPressed.");
                }
            }
            if (keyposition.Equals("KeyUp"))
            {
                keysPressed.Remove(key);
            }
        }
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