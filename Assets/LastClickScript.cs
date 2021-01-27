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
                    var C = GameObject.Find("Main Camera");
                    Camera CC = GameObject.Find("Main Camera").GetComponent<Camera>();

                    print(C.transform.position);
                    var pos = CC.ScreenToWorldPoint(e.mousePosition);
                    print(pos);
                    pos.y = pos.y * -1;
                    this.transform.position = pos;


                    break;
                default:
                    // Ignore
                    break;
            }
        }
    }
}
