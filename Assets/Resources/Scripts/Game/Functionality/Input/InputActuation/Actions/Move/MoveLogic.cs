using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLogic
{
    public bool move(GameObject o, HashSet<Action> pressedActions, HashSet<Action> attemptedActions, HashSet<int> mouseButtonsPressed)
    {
        float speed = o.GetComponent<StatsHolder>().getSpeed();
        GameObject lastClick = GameObject.Find("LastClick");
        Vector3 lcPosition = GameObject.Find("LastClick").transform.position;
        Rigidbody2D objectRigidBody = o.GetComponent<Rigidbody2D>();
        bool leftClick = mouseButtonsPressed.Contains(0);
        bool ObjectMovedToPosition = lcPosition.Equals(objectRigidBody.transform.position);

        if (leftClick)
        {
            moveToPoint(objectRigidBody, Camera.main.ScreenToWorldPoint(Input.mousePosition), speed);
        }
        if (!leftClick)
        {
            KeyMove km = new KeyMove();
            if (km.checkIfActionsListed(pressedActions))
            {
                km.doit(o, pressedActions);
                lastClick.transform.position = o.transform.position;
            }
            else
            {

                if (Vector3.Distance(lcPosition, objectRigidBody.transform.position) < speed)
                {
                    objectRigidBody.MovePosition(lcPosition);
                }
                else if (!ObjectMovedToPosition)
                {
                    moveToPoint(objectRigidBody, lcPosition, speed);
                }
                else if (ObjectMovedToPosition)
                {
                    return false;
                }
            }
        }
        return true;
    }
    
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
