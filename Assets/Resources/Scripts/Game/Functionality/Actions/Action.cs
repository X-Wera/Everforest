using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action
{
    public void moveCardinal(GameObject o, bool upPressed, bool rightPressed, bool downPressed, bool leftPressed)
    {
        Rigidbody2D rigidBod = o.GetComponent<Rigidbody2D>();
        Stats stats = o.GetComponent<Stats>();
        float velx = 0f, vely = 0f;
        if (leftPressed)
        {
            velx--;
        }
        if (rightPressed)
        {
            velx++;
        }
        if (upPressed)
        {
            vely++;
        }
        if (downPressed)
        {
            vely--;
        }

        Vector2 movement = new Vector2(velx, vely);
        Vector2 position = Vector2.MoveTowards(rigidBod.position, rigidBod.position + movement, stats.getSpeed());
        rigidBod.MovePosition(position);

    }
    public void mouseMove(Rigidbody2D rb, Vector2 target, float speed)
    {
        moveToPoint(rb, target, speed);
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
