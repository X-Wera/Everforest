using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : EverForestObject
{
    protected float health = 0;

    public float getHealth()
    {
        return this.health;
    }
    public void setHealth(float f)
    {
        this.health = f;
    }
}
