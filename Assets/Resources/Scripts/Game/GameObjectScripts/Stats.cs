using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private float speed = 0f;

    void Start()
    {
        setSpeed(0.25f);
    }

    //speed
    public float getSpeed()
    {
        return this.speed;
    }

    public void setSpeed(float s)
    {
        this.speed = s;
    }
}
