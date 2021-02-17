using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledObjectActionActuator
{
    InputActionTranslator inputActionTranslator;
    ControlHandler controlHandler;

    public ControlledObjectActionActuator(UpdateHandler up, InputActionTranslator inputActionTranslator, ControlHandler controlHandler)
    {
        this.inputActionTranslator = inputActionTranslator;
        this.controlHandler = controlHandler;

        up.OnTick += tick;
    }

    private void tick()
    {
        Tuple<Queue<object>, HashSet<MouseAction>, HashSet<KeyAction>> inputsReceived = inputActionTranslator.getInputsReceived();
        foreach (GameObject o in controlHandler.getControlledObjects())
        {
            doAction(o, inputsReceived);
        }

    }

    private void doAction(GameObject o, Tuple<Queue<object>, HashSet<MouseAction>, HashSet<KeyAction>> inputsReceived)
    {

        if (inputsReceived.Item2.Contains(MouseAction.PrimaryAction)
         || inputsReceived.Item2.Contains(MouseAction.PrimaryActionShift)
         || inputsReceived.Item2.Contains(MouseAction.PrimaryActionControl)
         || inputsReceived.Item2.Contains(MouseAction.PrimaryActionAlt)
         || inputsReceived.Item2.Contains(MouseAction.PrimaryActionCommand)
         || inputsReceived.Item2.Contains(MouseAction.PrimaryActionFunction))
        {
            InputTool inputTool = new InputTool();
            GameObject clickedObject = inputTool.checkIfItemAtScreenPosition(Input.mousePosition);
            if (clickedObject != null)
            {
                //Debug.Log(clickedObject.name);
            }
            else
            {
                if (o.GetComponent<Rigidbody2D>() != null && o.GetComponent<Stats>() != null)
                    new Action().mouseMove(o.GetComponent<Rigidbody2D>(), Input.mousePosition, o.GetComponent<Stats>().getSpeed());
                else
                    Debug.LogError(o + " : " + o.name + ": Requires both a Rigidbody2D & StatsHolder component to move.");
            }
        }
    }
}
