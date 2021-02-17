using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTool
{
    public GameObject checkIfItemAtScreenPosition(Vector2 mousePos)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject != null)
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }
}