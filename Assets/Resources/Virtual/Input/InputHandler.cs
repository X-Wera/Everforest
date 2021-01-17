using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// CURRENTLY ONLY HANDLES KEY AND MOUSE ACTIONS
public class InputHandler : MonoBehaviour
{
    //All currently pressed mouse buttons
    bool leftclicked = false;
    bool rightclicked = false;
    bool middleclicked = false;
    
    // Holds all currently pressed keys
    HashSet<string> keysPressed = new HashSet<string>();

    // Holds all keys that have been pressed in order of when they were received.
    Queue<string> pressedQueue = new Queue<string>();

    void OnGUI()
    {

        Event e = Event.current;

        // MOUSE HANDLING CODE
        if (e.isMouse)
        {

            if (e.type.ToString().Equals("mouseUp"))
            {
                switch (e.button.ToString())
                {
                    case "2":
                        middleclicked = false;
                        break;
                    case "1":
                        rightclicked = false;
                        break;
                    case "0":
                        leftclicked = false;
                        break;
                    default:
                        // Ignore
                        break;
                }
            }
            if (e.type.ToString().Equals("mouseDown"))
            {
                switch (e.button.ToString())
                {
                    case "2":
                        middleclicked = true;
                        break;
                    case "1":
                        rightclicked = true;
                        break;
                    case "0":
                        leftclicked = true;
                        break;
                    default:
                        // Ignore
                        break;
                }
            }
            //print(e.mousePosition.ToString());
        }


        // KEY HANDLING CODE
        if (e.isKey)
        {

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
    }
    // MOUSE BUTTONS PRESSED
    public bool isLeftMouseButtonPressed()
    {
        return leftclicked;
    }

    public bool isRightMouseButtonPressed()
    {
        return rightclicked;
    }
    public bool isMIddleMouseButtonPressed()
    {
        return middleclicked; ;
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