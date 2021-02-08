using System;
using System.Collections.Generic;
using UnityEngine;

public class InputActuator
{
    GameObject clickedObject = null;

    public void acceptInput(Queue<KeyCode> keyQ, Queue<Tuple<Vector3, HashSet<int>>> mouseQ, HashSet<KeyCode> keysPressed, HashSet<int> mouseButtonsPressed, KeyActionBinding kab, ControlHandler controlHandler)
    {

        HashSet<Action> attemptedActions = new HashSet<Action>();
        HashSet<Action> pressedActions = new HashSet<Action>();

        GameObject cObject = checkIfItemClicked(mouseQ);
        if (cObject != null)
        {
            clickedObject = cObject;
        }


        convertInputToActions(mouseQ, keyQ, keysPressed, attemptedActions, pressedActions, kab);

        foreach (GameObject o in controlHandler.getControlledObjects())
        {
            if (clickedObject != null)
            {
                if (o.GetComponent<Collider2D>().IsTouching(clickedObject.GetComponent<Collider2D>()))
                {
                    MonoBehaviour.print(o.name + " and " + clickedObject.name);
                    GameObject.Find("LastClick").transform.position = o.transform.position;
                    clickedObject = null;
                }
            }
            bool moved = new MoveLogic().move(o, pressedActions, attemptedActions, mouseButtonsPressed);
        }


        keyQ.Clear();
        mouseQ.Clear();

    }

    private GameObject checkIfItemClicked(Queue<Tuple<Vector3, HashSet<int>>> mouseQ)
    {
        foreach (Tuple<Vector3, HashSet<int>> clickData in mouseQ)
        {
            if (clickData.Item2.Contains(0))
            {
                Vector3 mousePos = clickData.Item1;
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos2D), Vector2.zero);
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider.gameObject.name);
                    //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                    //MonoBehaviour.print(hit.collider.gameObject.name);
                    return hit.collider.gameObject;
                }
            }
        }
        return null;
    }

    private void convertInputToActions(Queue<Tuple<Vector3, HashSet<int>>> mouseQ, Queue<KeyCode> keyQ, HashSet<KeyCode> keysPressed, HashSet<Action> attemptedActions, HashSet<Action> pressedActions, KeyActionBinding kab)
    {
        // Figure out what the hell the user is doing.
        foreach (KeyCode key in keyQ)
        {
            attemptedActions.Add(kab.getBoundAction(key));
        }
        foreach (KeyCode key in keysPressed)
        {
            pressedActions.Add(kab.getBoundAction(key));
        }
    }
}