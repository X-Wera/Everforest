using System;
using System.Collections.Generic;
using UnityEngine;

public class InputActuator
{
    public void acceptInput(Queue<KeyCode> keyQ, Queue<Tuple<Vector3, HashSet<int>>> mouseQ, HashSet<KeyCode> keysPressed, HashSet<int> mouseButtonsPressed, KeyActionBinding kab, ControlHandler controlHandler)
    {
        HashSet<Action> attemptedActions = new HashSet<Action>();
        HashSet<Action> pressedActions = new HashSet<Action>();
        HashSet<GameObject> controlledObjects = controlHandler.getControlledObjects();
        float speed = 0;


        // Figure out what the hell the user is doing.
        foreach (KeyCode key in keyQ)
        {
            attemptedActions.Add(kab.getBoundAction(key));
        }
        foreach (KeyCode key in keysPressed)
        {
            pressedActions.Add(kab.getBoundAction(key));
        }


        foreach (GameObject o in controlledObjects)
        {
            speed = o.GetComponent<StatsHolder>().getSpeed();
            if (mouseButtonsPressed.Contains(0))
            {
                double deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - o.GetComponent<Rigidbody2D>().position.x;
                double deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - o.GetComponent<Rigidbody2D>().position.y;

                double direction = Math.Atan2(deltaY, deltaX);

                float elx = (float)(o.GetComponent<Rigidbody2D>().position.x + (speed * Math.Cos(direction)));
                float ely = (float)(o.GetComponent<Rigidbody2D>().position.y + (speed * Math.Sin(direction)));

                o.GetComponent<Rigidbody2D>().MovePosition(new Vector2(elx, ely));
            }
            else
            {

                if (new KeyMove().doit(o, pressedActions))
                {
                    GameObject.Find("LastClick").transform.position = o.transform.position;
                }
                else
                {


                    double deltaX = GameObject.Find("LastClick").transform.position.x - o.GetComponent<Rigidbody2D>().position.x;
                    double deltaY = GameObject.Find("LastClick").transform.position.y - o.GetComponent<Rigidbody2D>().position.y;


                    double direction = Math.Atan2(deltaY, deltaX);

                    float elx = (float)(o.GetComponent<Rigidbody2D>().position.x + (speed * Math.Cos(direction)));
                    float ely = (float)(o.GetComponent<Rigidbody2D>().position.y + (speed * Math.Sin(direction)));

                    o.GetComponent<Rigidbody2D>().MovePosition(new Vector2(elx, ely));

                    if (Vector3.Distance(GameObject.Find("LastClick").transform.position, o.GetComponent<Rigidbody2D>().transform.position) < speed)
                    {
                        o.GetComponent<Rigidbody2D>().MovePosition(GameObject.Find("LastClick").transform.position);
                    }
                }

            }
        }
        keyQ.Clear();
        mouseQ.Clear();
    }
}