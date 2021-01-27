using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    GameObject gio;
    GameInitScript script;




    // Update is called once per frame
    void Update()
    {

        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
