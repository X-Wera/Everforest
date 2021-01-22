using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    Health health;
    Armor armor;
    Speed speed;

    // Start is called before the first frame update
    void Start()
    {
        health = this.gameObject.AddComponent<Health>() as Health;
        armor = this.gameObject.AddComponent<Armor>() as Armor;
        speed = this.gameObject.AddComponent<Speed>() as Speed;

        health.setMaxHP(100);
        health.maxHP();

        armor.setArmored(true);
        armor.setArmorLevel(1);

        speed.setSpeed(0.1);
    }

    public double getSpeed()
    {
        return speed.getSpeed();
    }

    public void setSpeed(double d)
    {
        speed.setSpeed(d);
    }
}
