using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler
{
    bool leftclicked = false;
    bool rightclicked = false;
    bool middleclicked = false;
    private Vector3 target;


    public void mouseAction(Event e)
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
    
    public bool getLeftClicked()
    {
        return leftclicked;
    }
    public bool getRightClicked()
    {
        return rightclicked;
    }
    public bool getMiddleClicked()
    {
        return middleclicked;
    }
}
