using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBinding
{
    // Keys
    Dictionary<KeyCode, KeyAction> BoundKeys = new Dictionary<KeyCode, KeyAction>();
    public bool bindKeyToAction(KeyCode key, KeyAction action)
    {
        if (!isKeyBound(key))
        {
            BoundKeys.Add(key, action);
            return false;
        }
        else
        {
            BoundKeys[key] = action;
            return true;
        }
    }
    public bool unbindKey(KeyCode key)
    {
        return BoundKeys.Remove(key);
    }

    public KeyAction getKeysBoundAction(KeyCode key)
    {
        KeyAction value = KeyAction.NoAction;
        BoundKeys.TryGetValue(key, out value);
        return value;
    }
    public HashSet<KeyCode> getActionsBoundKeys(KeyAction a)
    {
        HashSet<KeyCode> actionsBoundKeys = new HashSet<KeyCode>();
        foreach (KeyValuePair<KeyCode, KeyAction> kvp in BoundKeys)
            if (kvp.Value.Equals(a))
                actionsBoundKeys.Add(kvp.Key);
        return actionsBoundKeys;
    }

    public bool isKeyBound(KeyCode key)
    {
        return BoundKeys.ContainsKey(key);
    }
    public bool isKeyActionBound(KeyAction a)
    {
        return BoundKeys.ContainsValue(a);
    }

    public Dictionary<KeyCode, KeyAction> getAllKeyActionBindings()
    {
        return BoundKeys;
    }

    // Mouse
    Dictionary<int, MouseAction> BoundMouseButtons = new Dictionary<int, MouseAction>();
    public bool bindMouseButtonToAction(int button, MouseAction action)
    {
        if (!isMouseButtonBound(button))
        {
            BoundMouseButtons.Add(button, action);
            return false;
        }
        else
        {
            BoundMouseButtons[button] = action;
            return true;
        }
    }
    public bool unbindMouseButton(int button)
    {
        return BoundMouseButtons.Remove(button);
    }

    public MouseAction getMouseButtonsBoundAction(int button)
    {
        MouseAction value = MouseAction.NoAction;
        BoundMouseButtons.TryGetValue(button, out value);
        return value;
    }
    public HashSet<int> getActionsBoundKeys(MouseAction action)
    {
        HashSet<int> actionsBoundMouseButtons = new HashSet<int>();
        foreach (KeyValuePair<int, MouseAction> kvp in BoundMouseButtons)
            if (kvp.Value.Equals(action))
                actionsBoundMouseButtons.Add(kvp.Key);
        return actionsBoundMouseButtons;
    }

    public bool isMouseButtonBound(int button)
    {
        return BoundMouseButtons.ContainsKey(button);
    }
    public bool isMouseActionBound(MouseAction action)
    {
        return BoundMouseButtons.ContainsValue(action);
    }

    public Dictionary<int, MouseAction> getAllMouseActionBindings()
    {
        return BoundMouseButtons;
    }
}