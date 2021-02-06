﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove
{
    bool l = false, r = false, u = false, d = false;
    float speed = 0;
    float velx = 0, vely = 0;

    public KeyMove(GameObject o, HashSet<Action> inp)
    {
        if (o.GetComponent<Rigidbody2D>() != null && o.GetComponent<StatsHolder>() != null && o.GetComponent<StatsHolder>() != null)
        {
            speed = o.GetComponent<StatsHolder>().getSpeed();
            whichArrowsArePressed(inp);
            //If all directions are pressed no movement needs to be calculated.
            if (u && d && l && r)
            {
                return;
            }
            if (l)
            {
                velx--;
            }
            if (r)
            {
                velx++;
            }
            if (u)
            {
                vely++;
            }
            if (d)
            {
                vely--;
            }

            Vector2 movement = new Vector2(velx, vely);
            o.GetComponent<Rigidbody2D>().AddForce(movement * speed);

            velx = 0;
            vely = 0;
        }

        else
        { throw new Exception("Game Object " + o + " is missing components!"); }
    }


    void whichArrowsArePressed(HashSet<Action> i)
    {
        u = i.Contains(Action.MoveUp);
        r = i.Contains(Action.MoveRight);
        l = i.Contains(Action.MoveLeft);
        d = i.Contains(Action.MoveDown);
    }
}