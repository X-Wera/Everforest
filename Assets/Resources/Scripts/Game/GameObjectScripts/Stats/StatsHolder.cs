using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHolder : MonoBehaviour
{
    private Health health;
    private Armor armor;
    private Speed speed;
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

        speed.setSpeed(0.25f);
    }



    //speed
    public float getSpeed()
    {
        return speed.getSpeed();
    }

    public void setSpeed(float d)
    {
        speed.setSpeed(d);
    }
}
