using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Concurrent;

public class InputHandler : MonoBehaviour
{

    static readonly HashSet<string> keysPressed = new HashSet<string>();
    static readonly Queue<string> PressedQeue = new Queue<string>();

    void OnGUI()
    {

        Event e = Event.current;

        string keyposition = e.type.ToString();
        string key = e.keyCode.ToString();

        if (!key.Equals("None"))
        {
            if (keyposition.Equals("KeyDown"))
            {
                try
                {
                    keysPressed.Add(key);

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
    public HashSet<string> getKeysPressed()
    {
        return keysPressed;
    }


}





