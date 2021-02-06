using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActionBinding
{
    Dictionary<KeyCode, Action> BoundKeys = new Dictionary<KeyCode, Action>();

    public void bindKeyAction(KeyCode key, Action action)
    {
        if (!isKeyBound(key))
        {
            BoundKeys.Add(key, action);
        }
        else
        {
            BoundKeys[key] = action;
        }
    }

    public Action getBoundAction(KeyCode key)
    {
        Action value = Action.NoAction;
        BoundKeys.TryGetValue(key, out value);
        return value;
    }


    bool isKeyBound(KeyCode key)
    {
        return BoundKeys.ContainsKey(key);
    }

    public Dictionary<KeyCode, Action> getAllActions()
    {
        return BoundKeys;
    }


}
