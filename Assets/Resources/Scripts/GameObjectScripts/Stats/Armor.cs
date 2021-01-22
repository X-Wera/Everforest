using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    int armorLevel = 0;
    double armor = 0;
    bool armored = false;

    public double calcDamage(double damage)
    {
        if (armored)
        {
            double percentReduction = armor / 100;

            if (percentReduction > 0.99 || IsNegative(percentReduction))
            {
                return 0;
            }

            double damageReduction = percentReduction * damage;
            double finalDamage = damage - damageReduction;
            finalDamage = Math.Ceiling(finalDamage);
            return finalDamage;
        }
        else
        {
            damage = Math.Ceiling(damage);
            return damage;
        }

    }

    bool IsNegative(double d)
    {
         return d < 0;
    }

    public void setArmorLevel(int i)
    {
        armorLevel = i;
        armor = 0.44 * i;
    }

    public int getArmorLevel()
    {
        return armorLevel;
    }

    public void setArmored(bool b)
    {
        armored = b;
    }

    public bool getArmored()
    {
        return armored;
    }
}
