using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Called when this object first touches another.
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        // Called every framw as long as this object is touching another.
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        // Called when this object STOPS touching another object.
    }
}