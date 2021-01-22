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

        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = this.transform.position;
        //target.y = target.y * -1;
        this.transform.position = target;
    }
}
