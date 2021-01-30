using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastClickScript : MonoBehaviour
{

    void OnGUI()
    {

        Event e = Event.current;
        if (e.type.ToString().Equals("mouseDown"))
        {
            switch (e.button.ToString())
            {
                case "0":
                    this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    break;
                default:
                    // Ignore
                    break;
            }
        }
    }
}
