using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : EverForestObject
{
    private float health = 0;

    public float getHealth()
    {
        return this.health;
    }
    public void setHealth(float f)
    {
        this.health = f;
        if (health <= 0)
            expire();
    }

    public void expire()
    {
        gameManager.getObjectHandler().destroyObject(this.gameObject);
    }
}
