using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActionTranslator : MonoBehaviour
{
    ActionBinding actionBinding;

    public delegate void Configure(HashSet<KeyAction> ka, HashSet<MouseAction> ma);

    public event Configure OnConfigure;

    Queue<Tuple<KeyAction, KeyPosition>> keyActionsQ = new Queue<Tuple<KeyAction, KeyPosition>>();
    Queue<Tuple<MouseAction, Vector2, MouseButtonPosition>> mouseActionsQ = new Queue<Tuple<MouseAction, Vector2, MouseButtonPosition>>();
    Queue<Vector2> scrollQ = new Queue<Vector2>();
    Queue<ActionType> inputOrder = new Queue<ActionType>();
    private enum ActionType
    {
        Key, Mouse, Scroll
    }

    void Update()
    {
        InputHandler inputHandler = GetComponent<InputHandler>();

        HashSet<KeyAction> currentlyPressedKeys = new HashSet<KeyAction>();
        HashSet<MouseAction> currentlyPressedMouseButtons = new HashSet<MouseAction>();
        foreach (KeyCode key in inputHandler.getKeysCurrentlyPressed())
        {
            currentlyPressedKeys.Add(actionBinding.getKeysBoundAction(key));
        }
        foreach (int button in inputHandler.getMouseButtonsCurrentlyPressed())
        {
            currentlyPressedMouseButtons.Add(actionBinding.getMouseButtonsBoundAction(button));
        }

        OnConfigure(currentlyPressedKeys, currentlyPressedMouseButtons);

        keyActionsQ.Clear();
        mouseActionsQ.Clear();
        scrollQ.Clear();
        inputOrder.Clear();

    }

    private void OnEnable()
    {
        actionBinding = GetComponent<GameInitScript>().actionBinding;

        InputHandler inputHandler = GetComponent<InputHandler>();
        if (inputHandler == null)
            throw new Exception(this + " Input Configuration was unable to retrieve the InputHandler script from the GameInitializerObject.");
        inputHandler.OnMouseDown += mouseDown;
        inputHandler.OnMouseUp += mouseUp;
        inputHandler.OnMouseDrag += mouseDrag;
        inputHandler.OnKeyDown += keyDown;
        inputHandler.OnKeyUp += keyUp;
        inputHandler.OnScrollWheel += scroll;
    }
    private void OnDisable()
    {
        InputHandler inputHandler = GetComponent<InputHandler>();
        if (inputHandler == null)
            throw new Exception(this + " Input Configuration was unable to retrieve the InputHandler script from the GameInitializerObject.");
        inputHandler.OnMouseDown -= mouseDown;
        inputHandler.OnMouseUp -= mouseUp;
        inputHandler.OnMouseDrag -= mouseDrag;
        inputHandler.OnKeyDown -= keyDown;
        inputHandler.OnKeyUp -= keyUp;
        inputHandler.OnScrollWheel -= scroll;
    }

    private void mouseDown(int button, Vector2 mousePos)
    {
        inputOrder.Enqueue(ActionType.Mouse);
        mouseActionsQ.Enqueue(new Tuple<MouseAction, Vector2, MouseButtonPosition>(actionBinding.getMouseButtonsBoundAction(button), mousePos, MouseButtonPosition.Down));
    }
    private void mouseUp(int button, Vector2 mousePos)
    {
        inputOrder.Enqueue(ActionType.Mouse);
        mouseActionsQ.Enqueue(new Tuple<MouseAction, Vector2, MouseButtonPosition>(actionBinding.getMouseButtonsBoundAction(button), mousePos, MouseButtonPosition.Up));
    }
    private void mouseDrag(int button, Vector2 mousePos)
    {
        inputOrder.Enqueue(ActionType.Mouse);
        mouseActionsQ.Enqueue(new Tuple<MouseAction, Vector2, MouseButtonPosition>(actionBinding.getMouseButtonsBoundAction(button), mousePos, MouseButtonPosition.Drag));
    }
    private void keyDown(KeyCode key)
    {
        inputOrder.Enqueue(ActionType.Key);
        keyActionsQ.Enqueue(new Tuple<KeyAction, KeyPosition>(actionBinding.getKeysBoundAction(key), KeyPosition.Down));
    }
    private void keyUp(KeyCode key)
    {
        inputOrder.Enqueue(ActionType.Key);
        keyActionsQ.Enqueue(new Tuple<KeyAction, KeyPosition>(actionBinding.getKeysBoundAction(key), KeyPosition.Up));
    }
    private void scroll(Vector2 delta)
    {
        inputOrder.Enqueue(ActionType.Scroll);
        scrollQ.Enqueue(delta);
    }
}
