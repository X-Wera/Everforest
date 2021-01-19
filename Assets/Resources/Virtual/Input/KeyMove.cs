using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove
{
    bool arrows = true, wasd = true;
    bool l = false, r = false, u = false, d = false;
    double speed = 0;
    double velx = 0, vely = 0;

    public KeyMove(GameObject o, HashSet<string> input, double s)
    {
        speed = s;
        whichArrowsArePressed(input);
        //If all directions are pressed no movement needs to be calculated.
        if (u && d && l && r)
        {
            return;
        }
        if (onePressed())
        {
            o.transform.position = o.transform.position + new Vector3((float)velx, (float)vely);
            return;
        }
        if (twoPressed())
        {
            o.transform.position = o.transform.position + new Vector3((float)velx, (float)vely);
            return;
        }
        if (threePressed())
        {
            o.transform.position = o.transform.position + new Vector3((float)velx, (float)vely);
            return;
        }
    }
    bool threePressed()
    {
        //ThreePressed is somewhat useless do to hardware constraints and your keyboard not being able to process 3 keys at once.
        bool threePress = false;
        if (u && !d && l && r)
        {
            //up
            vely = 0;
            vely += speed;
            threePress = true;
        }
        if (!u && d && l && r)
        {
            //down
            vely = 0;
            vely -= speed;
            threePress = true;
        }
        if (u && d && l && !r)
        {
            //left
            velx = 0;
            velx -= speed;
            threePress = true;
        }
        if (!u && d && l && r)
        {
            //down
            velx = 0;
            velx += speed;
            threePress = true;
        }
        return threePress;
    }
    bool twoPressed()
    {
        bool twoPress = false;
        if (u && !d && l && !r)
        {
            //up and left
            vely += speed / 2;
            velx -= speed / 2;
            twoPress = true;
        }
        if (!u && d && l && !r)
        {
            //down and left
            vely -= speed / 2;
            velx -= speed / 2;
            twoPress = true;
        }
        if (u && !d && !l && r)
        {
            //up and right
            vely += speed / 2;
            velx += speed / 2;
            twoPress = true;
        }
        if (!u && d && !l && r)
        {
            //down and right
            velx += speed / 2;
            vely -= speed / 2;
            twoPress = true;
        }
        return twoPress;
    }
    bool onePressed()
    {
        bool onePress = false;
        if (u && !d && !l && !r)
        {
            //up
            vely += speed;
            onePress = true;
        }
        if (!u && d && !l && !r)
        {
            //down
            vely -= speed;
            onePress = true;
        }
        if (!u && !d && l && !r)
        {
            //left
            velx -= speed;
            onePress = true;
        }
        if (!u && !d && !l && r)
        {
            //down
            velx += speed;
            onePress = true;
        }
        return onePress;

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
