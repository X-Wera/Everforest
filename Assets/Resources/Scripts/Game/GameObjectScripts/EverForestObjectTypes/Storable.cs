using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storable : Destructible
{
    public int storageWidth { get; set; }
    public int storageHeight { get; set; }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Coin Collected");
        expire();
    }
}
