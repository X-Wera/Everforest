using System;
using System.Collections.Generic;
using UnityEngine;

public class InputActuator
{


    public void acceptInput(Stack<KeyCode> keyStack, Queue<Tuple<Vector3, HashSet<int>>> mouseQ, HashSet<KeyCode> keysPressed, HashSet<int> mouseButtonsPressed, KeyActionBinding kab, ControlHandler controlHandler, ObjectHandler oh)
    {

        Queue<Action> attemptedActions = getAttemptedActions(keyStack, kab);
        HashSet<Action> pressedActions = getPressedActions(keysPressed, kab);
        Queue<GameObject> clickedObjects = checkIfItemClicked(mouseQ);
        /*
        A lot of things will go here until I figure out how this game is gonna work.
        */
        foreach (GameObject o in controlHandler.getControlledObjects())
        {
            checkObjectsTouched(o, oh, clickedObjects);
            ActionLogic al = new ActionLogic();
            al.SingleObjectAction(o, pressedActions, attemptedActions, mouseButtonsPressed, checkIfItemClicked(mouseQ));

        }

        keyStack.Clear();
        mouseQ.Clear();

    }
    private void checkObjectsTouched(GameObject o, ObjectHandler oh, Queue<GameObject> clickedObjects)
    {
        HashSet<GameObject> allGameObjects = oh.getGameObjects();

        foreach (GameObject obj in allGameObjects)
        {
            if (o.GetComponent<Collider2D>().IsTouching(obj.GetComponent<Collider2D>()))
            {
                //MonoBehaviour.print(o.name + " touched " + obj.name);
                foreach (GameObject ob in clickedObjects)
                {
                    obj.Equals(ob);
                    o.GetComponent<Status>().setArrived(true);
                }
                //GameObject.Find("LastClick").transform.position = o.transform.position;

            }
        }
    }

    private Queue<GameObject> checkIfItemClicked(Queue<Tuple<Vector3, HashSet<int>>> mouseQ)
    {
        Queue<GameObject> allObjectsClickedThisUpdate = new Queue<GameObject>();
        foreach (Tuple<Vector3, HashSet<int>> clickData in mouseQ)
        {
            if (clickData.Item2.Contains(0))
            {
                Vector3 mousePos = clickData.Item1;
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos2D), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject != null)
                    {
                        allObjectsClickedThisUpdate.Enqueue(hit.collider.gameObject);
                        //MonoBehaviour.print(hit.collider.gameObject.name);
                    }
                }
            }
        }
        return allObjectsClickedThisUpdate;
    }

    private Queue<Action> getAttemptedActions(Stack<KeyCode> keyQ, KeyActionBinding kab)
    {
        Queue<Action> aa = new Queue<Action>();
        foreach (KeyCode key in keyQ)
        {
            aa.Enqueue(kab.getBoundAction(key));
        }
        return aa;
    }

    private HashSet<Action> getPressedActions(HashSet<KeyCode> keysPressed, KeyActionBinding kab)
    {
        HashSet<Action> pa = new HashSet<Action>();

        foreach (KeyCode key in keysPressed)
        {
            pa.Add(kab.getBoundAction(key));
        }
        return pa;
    }
}