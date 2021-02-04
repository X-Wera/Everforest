using System;
using UnityEngine;

public class MouseHandler

{
    public delegate void ClickAction(Vector3 mp, bool l, bool r, bool m);
    public static event ClickAction OnClicked;
    bool leftclicked = false, rightclicked = false, middleclicked = false;

    public void mouseAction(Event e)
    {
        determineClickUpDownAndButton(e);
        if (OnClicked != null)
        {
            OnClicked(Input.mousePosition, leftclicked, rightclicked, middleclicked);
        }
    }

    void determineClickUpDownAndButton(Event e)
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
    }
}
