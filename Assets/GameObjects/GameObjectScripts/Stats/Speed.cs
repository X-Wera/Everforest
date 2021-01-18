using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    double speed = 0;

    public double getSpeed()
    {
        return speed;
    }
    public void setSpeed(double d)
    {
        speed = d;
    }
}
