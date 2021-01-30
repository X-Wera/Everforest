using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    float speed = 0;

    public float getSpeed()
    {
        return speed;
    }
    public void setSpeed(float d)
    {
        speed = d;
    }
}
