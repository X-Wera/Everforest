using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // How many newtons of force this character can exert;
    private float strength = 0f;

    // How quickly your object can slow down and speed up.
    private float agility = 0f;

    // Max Stamina
    private float endurance = 0f;

    // Amount of Stamina regenerated every tick.
    private float vigor = 0f;

    // Current Stamina
    private float stamina = 0f;

    // PsudoAxis (Experimental)
    public float axis = 0f;

    void Start()
    {
        setStrength(5);
        setAgility(10);
    }

    void FixedUpdate()
    {

    }

    // stamina
    public float getStamina()
    {
        return this.stamina;
    }
    public void setStamina(float f)
    {
        if (f >= endurance)
            this.stamina = endurance;
        else
            this.stamina = f;
    }

    // endurance
    public float getEndurance()
    {
        return this.endurance;
    }
    public void setEndurance(float f)
    {
        this.endurance = f;
    }

    // weight
    public float getWeight()
    {
        return GetComponent<Rigidbody>().mass;
    }
    public void setWeight(float f)
    {
        GetComponent<Rigidbody>().mass = f;
    }
    // strength
    public float getStrength()
    {
        return this.strength;
    }
    public void setStrength(float f)
    {
        this.strength = f;
    }

    // agility
    public float getAgility()
    {
        return this.agility;
    }
    public void setAgility(float f)
    {
        this.agility = f;
    }
}
