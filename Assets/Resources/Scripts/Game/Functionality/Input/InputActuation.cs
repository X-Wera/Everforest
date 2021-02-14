using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActuation
{
    public InputActuation(InputActionTranslator inputActionTranslator, ObjectHandler objectHandler)
    {
        inputActionTranslator.OnConfigure += configure;
    }

    private void configure(HashSet<KeyAction> currentlyPressedKeys, HashSet<MouseAction> currentlyPressedMouseButtons)
    {
        bool noMouseButtonsArePressed = (currentlyPressedMouseButtons.Count == 0);
        bool noKeysArePressed = (currentlyPressedKeys.Count == 0);
    }

    private GameObject checkIfObjectClicked(Vector3 mousePos)
    {
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos2D), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject != null)
            {
                return hit.collider.gameObject;
            }
        }
        return null;
    }
    private void checkObjectsTouched(GameObject o, ObjectHandler oh)
    {
        foreach (GameObject obj in oh.getGameObjects())
            if (o.GetComponent<Collider2D>().IsTouching(obj.GetComponent<Collider2D>()))
            {
                //Object is touching something...
            }

    }
}