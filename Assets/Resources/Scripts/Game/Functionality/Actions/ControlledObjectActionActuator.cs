﻿using System;
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
            ActuateInput(o, inputsReceived);
        }

    }

    private void ActuateInput(GameObject o, Tuple<Queue<object>, HashSet<MouseAction>, HashSet<KeyAction>> inputsReceived)
    {
        bool primaryClicked = isPrimaryClicked(inputsReceived.Item2);
        bool upPressed = inputsReceived.Item3.Contains(KeyAction.MoveUp);
        bool rightPressed = inputsReceived.Item3.Contains(KeyAction.MoveRight);
        bool downPressed = inputsReceived.Item3.Contains(KeyAction.MoveDown);
        bool leftPressed = inputsReceived.Item3.Contains(KeyAction.MoveLeft);

        bool userAttemptingToMove = isUserAttemptingToMove(primaryClicked, upPressed, rightPressed, downPressed, leftPressed);

        if (!userAttemptingToMove)
            new Action().attemptToStopMoving(o);
        else
            new Action().moving(o);

        if (primaryClicked)
        {
            InputTool inputTool = new InputTool();
            GameObject clickedObject = inputTool.checkIfItemAtScreenPosition(Input.mousePosition);

            if (clickedObject != null)
                //Debug.Log(clickedObject.name);
                new Action().mouseMove(o, Input.mousePosition);
            else

                new Action().mouseMove(o, Input.mousePosition);
        }

        if (!primaryClicked)
            if (upPressed || rightPressed || downPressed || leftPressed)
                new Action().moveCardinal(o, upPressed, rightPressed, downPressed, leftPressed);
    }

    private bool isPrimaryClicked(HashSet<MouseAction> mouseInput)
    {
        if (mouseInput.Contains(MouseAction.PrimaryAction) || mouseInput.Contains(MouseAction.PrimaryActionShift) ||
            mouseInput.Contains(MouseAction.PrimaryActionControl) || mouseInput.Contains(MouseAction.PrimaryActionAlt) ||
            mouseInput.Contains(MouseAction.PrimaryActionCommand) || mouseInput.Contains(MouseAction.PrimaryActionFunction))
        {
            return true;
        }
        return false;
    }
    private bool isUserAttemptingToMove(bool primaryClicked, bool upPressed, bool rightPressed, bool downPressed, bool leftPressed)
    {
        if (primaryClicked || upPressed || rightPressed || downPressed || leftPressed)
        {
            return true;
        }
        return false;
    }
}
