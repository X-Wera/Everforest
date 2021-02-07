using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastClickScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        print(this);
    }
}
