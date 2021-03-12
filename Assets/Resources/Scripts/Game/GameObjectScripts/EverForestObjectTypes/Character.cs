using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Destructible

{
    void Start()
    {
        strength = 5;
        agility = 10;
        setStamina(0);
        endurance = 100;
        vigor = 100;
    }

    // How many newtons of force this character can exert;
    public float strength { get; set; }

    // How quickly your object can slow down and speed up.
    public float agility { get; set; }

    // Max Stamina
    private float endurance { get; set; }

    // Amount of Stamina regenerated every minute.
    public float vigor { get; set; }

    // Current energy that can be used to do things
    private float stamina = 0f;

    // stamina
    public float getStamina()
    {
        return this.stamina;
    }
    public void setStamina(float f)
    {
        if (f >= endurance)
            this.stamina = endurance;
        else if (f <= 0)
            this.stamina = 0;
        else
            this.stamina = f;
    }
}
