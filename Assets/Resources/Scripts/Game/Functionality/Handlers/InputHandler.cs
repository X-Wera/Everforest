using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private ActionHandler ah;
    protected GameObject gameManager;

    private readonly HashSet<CharacterAction> currentlyActive = new HashSet<CharacterAction>();
    private readonly HashSet<CharacterAction> activatedDuringThisFrame = new HashSet<CharacterAction>();
    private Dictionary<KeyCode, CharacterAction> BoundActions = new Dictionary<KeyCode, CharacterAction>();


    void Start()
    {
        ah = new ActionHandler(this);
        gameManager = GameObject.Find("Game(Clone)");
    }

    void FixedUpdate()
    {
        foreach (CharacterAction ca in currentlyActive)
            activatedDuringThisFrame.Add(ca);
        foreach (GameObject o in gameManager.GetComponent<GameManagerScript>().getControlHandler().getControlledObjects())
            ah.attemptActions(o, activatedDuringThisFrame);

        activatedDuringThisFrame.Clear();
    }

    void OnGUI()
    {
        Event e = Event.current;

        switch (e.type)
        {
            // Update Key Active
            case EventType.MouseDown:
                press(KeyCode.Mouse0);
                press(KeyCode.Mouse1);
                press(KeyCode.Mouse2);
                press(KeyCode.Mouse3);
                press(KeyCode.Mouse4);
                press(KeyCode.Mouse5);
                press(KeyCode.Mouse6);
                break;
            case EventType.MouseDrag:
                press(KeyCode.Mouse0);
                press(KeyCode.Mouse1);
                press(KeyCode.Mouse2);
                press(KeyCode.Mouse3);
                press(KeyCode.Mouse4);
                press(KeyCode.Mouse5);
                press(KeyCode.Mouse6);
                break;
            case EventType.KeyDown:
                press(e.keyCode);
                break;

            // Update Key InActive
            case EventType.MouseUp:
                unpress(KeyCode.Mouse0);
                unpress(KeyCode.Mouse1);
                unpress(KeyCode.Mouse2);
                unpress(KeyCode.Mouse3);
                unpress(KeyCode.Mouse4);
                unpress(KeyCode.Mouse5);
                unpress(KeyCode.Mouse6);
                break;
            case EventType.KeyUp:
                unpress(e.keyCode);
                break;
            default:
                // ignore
                break;
        }
    }

    private void press(KeyCode key)
    {
        // Double checks from system if mouse is currently pressed.
        if (Input.GetKey(key))
        {
            currentlyActive.Add(getBoundKeysAction(key));
            activatedDuringThisFrame.Add(getBoundKeysAction(key));
        }

    }
    private void unpress(KeyCode key)
    {
        // Double checks from system if mouse is currently unpressed.
        if (!Input.GetKey(key))
            currentlyActive.Remove(getBoundKeysAction(key));
    }

    public void ClearPressed()
    {
        activatedDuringThisFrame.Clear();
    }

    public CharacterAction getBoundKeysAction(KeyCode key)
    {
        if (BoundActions.ContainsKey(key))
            return BoundActions[key];
        else
            return CharacterAction.NoAction;
    }

    public HashSet<KeyCode> getBoundActionsKeys(CharacterAction ia)
    {
        HashSet<KeyCode> values = new HashSet<KeyCode>();
        foreach (KeyValuePair<KeyCode, CharacterAction> kvp in BoundActions)
            if (kvp.Value.Equals(ia))
                values.Add(kvp.Key);
        return values;
    }

    public void setBinding(KeyCode key, CharacterAction a)
    {
        if (BoundActions.ContainsKey(key))
            BoundActions[key] = a;
        else
            BoundActions.Add(key, a);
    }

    public HashSet<CharacterAction> getCurrentlyActiveButtons()
    {
        return currentlyActive;
    }

    public GameObject CheckIfObjectAtPostion(Vector2 mousePos)
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
