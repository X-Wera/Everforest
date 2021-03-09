using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActionTranslator
{
    private InputHandler inputHandler;
    private ActionBinding actionBinding;
    private GameManagerScript game;

    public InputActionTranslator(InputHandler inputHandler, ActionBinding actionBinding)
    {
        this.inputHandler = inputHandler;
        this.actionBinding = actionBinding;
    }

    public delegate void Configure(HashSet<KeyAction> ka, HashSet<MouseAction> ma);

    public Tuple<HashSet<MouseAction>, HashSet<KeyAction>> getInputsReceived()
    {
        HashSet<KeyAction> currentlyPressedKeys = new HashSet<KeyAction>();
        HashSet<MouseAction> currentlyPressedMouseButtons = new HashSet<MouseAction>();
        foreach (Tuple<KeyCode, EventModifiers> pressedKeyWithModifier in inputHandler.getKeysCurrentlyPressed())
        {
            currentlyPressedKeys.Add(actionBinding.getKeysBoundAction(pressedKeyWithModifier.Item1, pressedKeyWithModifier.Item2));
            //Debug.Log(pressedKeyWithModifier);
        }
        foreach (Tuple<int, EventModifiers> buttonsPressedWithModifiers in inputHandler.getMouseButtonsCurrentlyPressed())
        {
            currentlyPressedMouseButtons.Add(actionBinding.getMouseButtonsBoundAction(buttonsPressedWithModifiers.Item1, buttonsPressedWithModifiers.Item2));
        }
        Tuple<HashSet<MouseAction>, HashSet<KeyAction>> inputsPackaged = new Tuple<HashSet<MouseAction>, HashSet<KeyAction>>(currentlyPressedMouseButtons, currentlyPressedKeys);
        return inputsPackaged;
    }
}
