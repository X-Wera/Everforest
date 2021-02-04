using System;
using UnityEngine;


public class LastClickScript : MonoBehaviour
{
    bool leftPressed;

    void OnGUI()
    {

        Event e = Event.current;
        if (e.type.ToString().Equals("mouseDown"))
        {

            switch (e.button.ToString())
            {
                case "0":
                    leftPressed = true;
                    break;
                default:
                    // Ignore
                    break;
            }
        }
        if (e.type.ToString().Equals("mouseUp"))
        {
            switch (e.button.ToString())
            {
                case "0":
                    leftPressed = false;
                    break;
                default:
                    // Ignore
                    break;
            }
        }

        if (leftPressed)
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
