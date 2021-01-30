using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove
{
    bool arrows = true, wasd = true;
    bool l = false, r = false, u = false, d = false;
    float speed = 0;
    float velx = 0, vely = 0;

    public KeyMove(GameObject o, HashSet<string> input, float s)
    {
        speed = s;
        whichArrowsArePressed(input);
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

    void whichArrowsArePressed(HashSet<string> i)
    {
        if (arrows)
        {
            if (i.Contains("LeftArrow"))
            {
                l = true;
            }
            if (i.Contains("RightArrow"))
            {
                r = true;
            }
            if (i.Contains("UpArrow"))
            {
                u = true;
            }
            if (i.Contains("DownArrow"))
            {
                d = true;
            }
        }
        if (wasd)
        {
            if (i.Contains("A"))
            {
                l = true;
            }
            if (i.Contains("D"))
            {
                r = true;
            }
            if (i.Contains("W"))
            {
                u = true;
            }
            if (i.Contains("S"))
            {
                d = true;
            }
        }

    }
}
