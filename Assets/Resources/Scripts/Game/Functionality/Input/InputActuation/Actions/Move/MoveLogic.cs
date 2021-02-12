using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLogic
{
    public MoveLogic(GameObject o, HashSet<Action> pressedActions, Queue<Action> attemptedActions, HashSet<int> mouseButtonsPressed)
    {
        GameObject lastClick = GameObject.Find("LastClick");
        if (!o.GetComponent<Status>().getStopped())
        {
            float speed = o.GetComponent<StatsHolder>().getSpeed();

            Vector3 lcPosition = lastClick.transform.position;
            Rigidbody2D objectRigidBody = o.GetComponent<Rigidbody2D>();
            bool leftClick = mouseButtonsPressed.Contains(0);
            bool ObjectMovedToPosition = lcPosition.Equals(objectRigidBody.transform.position);

            if (leftClick)
            {
                moveToPoint(objectRigidBody, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed);
                o.GetComponent<Status>().setArrived(false);

            }
            else
            {

                KeyMove km = new KeyMove();
                if (km.checkIfActionsListed(pressedActions))
                {
                    km.doit(o, pressedActions);
                    lastClick.transform.position = o.transform.position;
                    o.GetComponent<Status>().setArrived(true);
                }
                else if (!o.GetComponent<Status>().getArrived())
                {

                    if (Vector3.Distance(lcPosition, objectRigidBody.transform.position) < speed)
                    {
                        objectRigidBody.MovePosition(lcPosition);
                        o.GetComponent<Status>().setArrived(true);
                    }
                    else if (!ObjectMovedToPosition)
                    {
                        moveToPoint(objectRigidBody, lcPosition, speed);
                    }
                }
            }
        }
        else
        {
            lastClick.transform.position = o.transform.position;
            o.GetComponent<Status>().setArrived(true);
        }
    }
    /*
    public void arrived()
    {
        GameObject.Find("LastClick").transform.position = this.gameObject.transform.position;
    }
    */

    private void moveToPoint(Rigidbody2D o, Vector3 target, float speed)
    {
        double deltaX = target.x - o.position.x;
        double deltaY = target.y - o.position.y;

        double direction = Math.Atan2(deltaY, deltaX);

        float elx = (float)(o.position.x + (speed * Math.Cos(direction)));
        float ely = (float)(o.position.y + (speed * Math.Sin(direction)));

        o.MovePosition(new Vector2(elx, ely));
    }
}
