using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBinding
{
    // Keys
    Dictionary<Tuple<KeyCode, EventModifiers>, KeyAction> BoundKeys = new Dictionary<Tuple<KeyCode, EventModifiers>, KeyAction>();
    public bool bindKeyToAction(KeyCode key, EventModifiers modifiers, KeyAction action)
    {
        if (!isKeyBound(new Tuple<KeyCode, EventModifiers>(key, modifiers)))
        {
            BoundKeys.Add(new Tuple<KeyCode, EventModifiers>(key, modifiers), action);
            return false;
        }
        else
        {
            BoundKeys[new Tuple<KeyCode, EventModifiers>(key, modifiers)] = action;
            return true;
        }
    }
    public bool unbindKey(KeyCode key, EventModifiers modifiers)
    {
        return BoundKeys.Remove(new Tuple<KeyCode, EventModifiers>(key, modifiers));
    }

    public KeyAction getKeysBoundAction(KeyCode key, EventModifiers modifiers)
    {
        KeyAction value = KeyAction.NoAction;
        BoundKeys.TryGetValue(new Tuple<KeyCode, EventModifiers>(key, modifiers), out value);
        return value;
    }
    public HashSet<Tuple<KeyCode, EventModifiers>> getActionsBoundKeys(KeyAction a)
    {
        HashSet<Tuple<KeyCode, EventModifiers>> actionsBoundKeys = new HashSet<Tuple<KeyCode, EventModifiers>>();
        foreach (KeyValuePair<Tuple<KeyCode, EventModifiers>, KeyAction> kvp in BoundKeys)
            if (kvp.Value == (a))
                actionsBoundKeys.Add(kvp.Key);
        return actionsBoundKeys;
    }

    public bool isKeyBound(Tuple<KeyCode, EventModifiers> key)
    {
        return BoundKeys.ContainsKey(key);
    }
    public bool isKeyActionBound(KeyAction a)
    {
        return BoundKeys.ContainsValue(a);
    }

    public Dictionary<Tuple<KeyCode, EventModifiers>, KeyAction> getAllKeyActionBindings()
    {
        return BoundKeys;
    }

    // Mouse
    Dictionary<Tuple<int, EventModifiers>, MouseAction> BoundMouseButtons = new Dictionary<Tuple<int, EventModifiers>, MouseAction>();
    public bool bindMouseButtonToAction(int button, EventModifiers modifiers, MouseAction action)
    {
        Tuple<int, EventModifiers> buttonsAndModifiers = new Tuple<int, EventModifiers>(button, modifiers);
        if (!isMouseButtonBound(button, modifiers))
        {
            BoundMouseButtons.Add(buttonsAndModifiers, action);
            return false;
        }
        else
        {
            BoundMouseButtons[buttonsAndModifiers] = action;
            return true;
        }
    }
    public bool unbindMouseButton(int button, EventModifiers modifiers)
    {

        return BoundMouseButtons.Remove(new Tuple<int, EventModifiers>(button, modifiers));
    }

    public MouseAction getMouseButtonsBoundAction(int button, EventModifiers modifiers)
    {
        MouseAction value = MouseAction.NoAction;
        BoundMouseButtons.TryGetValue(new Tuple<int, EventModifiers>(button, modifiers), out value);
        return value;
    }
    public HashSet<Tuple<int, EventModifiers>> getActionsBoundKeys(MouseAction action)
    {
        HashSet<Tuple<int, EventModifiers>> actionsBoundMouseButtons = new HashSet<Tuple<int, EventModifiers>>();
        foreach (KeyValuePair<Tuple<int, EventModifiers>, MouseAction> kvp in BoundMouseButtons)
            if (kvp.Value == (action))
                actionsBoundMouseButtons.Add(kvp.Key);
        return actionsBoundMouseButtons;
    }

    public bool isMouseButtonBound(int button, EventModifiers modifiers)
    {
        return BoundMouseButtons.ContainsKey(new Tuple<int, EventModifiers>(button, modifiers));
    }
    public bool isMouseActionBound(MouseAction action)
    {
        return BoundMouseButtons.ContainsValue(action);
    }

    public Dictionary<Tuple<int, EventModifiers>, MouseAction> getAllMouseActionBindings()
    {
        return BoundMouseButtons;
    }
}