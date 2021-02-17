using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public void mouseMove(Rigidbody2D rb, Vector2 target, float speed)
    {
        moveToPoint(rb,target,speed);
    }

    private void moveToPoint(Rigidbody2D o, Vector2 target, float speed)
    {
        Vector2 t = Camera.main.ScreenToWorldPoint(target);
        double deltaX = t.x - o.position.x;
        double deltaY = t.y - o.position.y;

        double direction = Math.Atan2(deltaY, deltaX);

        float elx = (float)(o.position.x + (speed * Math.Cos(direction)));
        float ely = (float)(o.position.y + (speed * Math.Sin(direction)));

        o.MovePosition(new Vector2(elx, ely));
    }
}
