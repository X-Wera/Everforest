using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Concurrent;

// Receives all keyboard and mouse inputs. Should only be used for ingame inputs. Designed for smooth handling of key & mouse events. Another sturdier
// or built-in input handler should be used for textboxes of any kind.
public class InputHandler : MonoBehaviour
{

    static readonly HashSet<string> keysPressed =
            new HashSet<string>();
    //static readonly Queue<string> keysTyped =
            //new Queue<string>();



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {

        Event e = Event.current;

        if (e.isMouse)
        {
            // print(e.button);
            // 0 - left button; 1 - right button; 2 - middle button
            // print(e.type);
            // mouseUp,mouseDown

        }


        if (e.isKey)
        {

            string keyposition = e.type.ToString();
            string key = e.keyCode.ToString();
            if (!key.Equals("None"))
            {
                if (keyposition.Equals("KeyDown"))
                {
                    //keysTyped.Enqueue(key);
                    try
                    {
                        keysPressed.Add(key);

                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Failed to add pressed key to keysPressed.");
                    }



                    //Add item to list of pressed buttons.
                }
                if (keyposition.Equals("KeyUp"))
                {
                    keysPressed.Remove(key);


                    //print(key);

                    //Remove item from list making it unpressed.
                }
            }
        }

        //print(e.type);
        // KeyUp,KeyDown
        //print(e.keyCode);
        // A,B,C,Return...


    }

    public HashSet<string> getKeysPressed()
    {
        return keysPressed;
    }

}


