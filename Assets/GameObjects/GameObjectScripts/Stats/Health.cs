using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public double maxHealth = 1;
    public double currentHealth = 1;

    public void setMaxHP(double i)
    {
        maxHealth = i;
    }

    public double getMaxHP()
    {
        return maxHealth;
    }

    public void maxHP()
    {
        currentHealth = maxHealth;
    }

    public void setCurrent(double i)
    {
        currentHealth = i;
    }

    public double getCurrent()
    {
        return currentHealth;
    }
}
