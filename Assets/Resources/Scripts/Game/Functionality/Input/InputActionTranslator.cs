using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActionTranslator
{
    private InputHandler inputHandler;
    private ActionBinding actionBinding;

    public InputActionTranslator(InputHandler inputHandler, ActionBinding actionBinding)
    {
        this.inputHandler = inputHandler;
        this.actionBinding = actionBinding;
    }

    public delegate void Configure(HashSet<KeyAction> ka, HashSet<MouseAction> ma);

    Queue<object> ActionQ = new Queue<object>();

    public Tuple<Queue<object>, HashSet<MouseAction>, HashSet<KeyAction>> getInputsReceived()
    {
        HashSet<KeyAction> currentlyPressedKeys = new HashSet<KeyAction>();
        HashSet<MouseAction> currentlyPressedMouseButtons = new HashSet<MouseAction>();
        foreach (Tuple<KeyCode, EventModifiers> pressedKeyWithModifier in inputHandler.getKeysCurrentlyPressed())
        {
            currentlyPressedKeys.Add(actionBinding.getKeysBoundAction(pressedKeyWithModifier.Item1, pressedKeyWithModifier.Item2));
            Debug.Log(pressedKeyWithModifier);
        }
        foreach (Tuple<int, EventModifiers> buttonsPressedWithModifiers in inputHandler.getMouseButtonsCurrentlyPressed())
        {
            currentlyPressedMouseButtons.Add(actionBinding.getMouseButtonsBoundAction(buttonsPressedWithModifiers.Item1, buttonsPressedWithModifiers.Item2));
        }
        Tuple<Queue<object>, HashSet<MouseAction>, HashSet<KeyAction>> inputsPackaged = new Tuple<Queue<object>, HashSet<MouseAction>, HashSet<KeyAction>>(ActionQ, currentlyPressedMouseButtons, currentlyPressedKeys);
        ActionQ.Clear();
        return inputsPackaged;
    }

    private void OnEnable()
    {
        inputHandler.OnMouseDown += mouseDown;
        inputHandler.OnMouseUp += mouseUp;
        inputHandler.OnMouseDrag += mouseDrag;
        inputHandler.OnKeyDown += keyDown;
        inputHandler.OnKeyUp += keyUp;
        inputHandler.OnScrollWheel += scroll;
    }
    private void OnDisable()
    {
        inputHandler.OnMouseDown -= mouseDown;
        inputHandler.OnMouseUp -= mouseUp;
        inputHandler.OnMouseDrag -= mouseDrag;
        inputHandler.OnKeyDown -= keyDown;
        inputHandler.OnKeyUp -= keyUp;
        inputHandler.OnScrollWheel -= scroll;
    }

    private void mouseDown(int button, EventModifiers modifiers, Vector2 mousePos)
    {
        ActionQ.Enqueue(new Tuple<MouseAction, Vector2, MouseButtonPosition>(actionBinding.getMouseButtonsBoundAction(button, modifiers), mousePos, MouseButtonPosition.Down));
    }
    private void mouseUp(int button, EventModifiers modifiers, Vector2 mousePos)
    {
        ActionQ.Enqueue(new Tuple<MouseAction, Vector2, MouseButtonPosition>(actionBinding.getMouseButtonsBoundAction(button, modifiers), mousePos, MouseButtonPosition.Up));
    }
    private void mouseDrag(int button, EventModifiers modifiers, Vector2 mousePos)
    {
        ActionQ.Enqueue(new Tuple<MouseAction, Vector2, MouseButtonPosition>(actionBinding.getMouseButtonsBoundAction(button, modifiers), mousePos, MouseButtonPosition.Drag));
    }

    private void keyDown(KeyCode key, EventModifiers modifiers)
    {
        ActionQ.Enqueue(new Tuple<KeyAction, KeyPosition>(actionBinding.getKeysBoundAction(key, modifiers), KeyPosition.Down));
    }
    private void keyUp(KeyCode key, EventModifiers modifiers)
    {
        ActionQ.Enqueue(new Tuple<KeyAction, KeyPosition>(actionBinding.getKeysBoundAction(key, modifiers), KeyPosition.Up));
    }

    private void scroll(Vector2 delta)
    {
        ActionQ.Enqueue(delta);
    }
}
