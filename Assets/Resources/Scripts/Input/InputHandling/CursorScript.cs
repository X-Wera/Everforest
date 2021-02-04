using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    GameObject gio;
    GameInitScript script;


    void OnGUI()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
