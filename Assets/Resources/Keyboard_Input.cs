using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Keyboard_Input : MonoBehaviour


{
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
        // Receives all keyboard and mouse inputs.
        Event e = Event.current;
        if (e.isMouse)
        {
            //print(e);
            print(e.button);
            print(e.type);
        }
        if (e.isKey)
        {
            //if (e.Equals(Event.KeyboardEvent("return")))
            //{
            //    print("return");
            //}
            //print.(e);
            print(e.type);
            print(e.keyCode);


        }

    }

}
