using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject mainCameraObject;
    public GameObject groundObject;
    public GameObject resourceObject;

    public ActionBinding actionBinding;
    private ControlHandler controlHandler;
    private EnvironmentManager environmentManager;
    private InputActionTranslator inputActionTranslator;
    private InputHandler inputHandler;
    private ObjectHandler objectHandler;
    private ResourceLoader resource;
    private UpdateHandler updateHandler;
    private ControlledObjectActionActuator coaa;

    void Start()
    {
        initGame();
    }

    public void initGame()
    {
        initCoreComponents();
        TestingMethodKillMeLaterImBeggingYouPLEEAAAASEEEEEEEEEE();
        environmentManager.initializeEnvironment();
    }

    private void TestingMethodKillMeLaterImBeggingYouPLEEAAAASEEEEEEEEEE()
    {
        // NEED TO GET ACTION BINDINGS FROM MAIN MENU AND BEFORE THAT THEY SHOULD ALL BE SET TO WHAT WE WANT THE DEFAULT KEYS TO BE.

        // WASD
        actionBinding.bindKeyToAction(KeyCode.W, EventModifiers.None, KeyAction.MoveUp);
        actionBinding.bindKeyToAction(KeyCode.D, EventModifiers.None, KeyAction.MoveRight);
        actionBinding.bindKeyToAction(KeyCode.S, EventModifiers.None, KeyAction.MoveDown);
        actionBinding.bindKeyToAction(KeyCode.A, EventModifiers.None, KeyAction.MoveLeft);

        // ARROW KEYS
        actionBinding.bindKeyToAction(KeyCode.UpArrow, EventModifiers.FunctionKey, KeyAction.MoveUp);
        actionBinding.bindKeyToAction(KeyCode.RightArrow, EventModifiers.FunctionKey, KeyAction.MoveRight);
        actionBinding.bindKeyToAction(KeyCode.DownArrow, EventModifiers.FunctionKey, KeyAction.MoveDown);
        actionBinding.bindKeyToAction(KeyCode.LeftArrow, EventModifiers.FunctionKey, KeyAction.MoveLeft);

        // MOUSE BUTTONS
        actionBinding.bindMouseButtonToAction(0, EventModifiers.None, MouseAction.PrimaryAction);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.Shift, MouseAction.PrimaryActionShift);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.Control, MouseAction.PrimaryActionControl);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.Alt, MouseAction.PrimaryActionAlt);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.Command, MouseAction.PrimaryActionCommand);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.FunctionKey, MouseAction.PrimaryActionFunction);
    }

    private void initCoreComponents()
    {
        actionBinding = new ActionBinding();
        controlHandler = new ControlHandler();
        inputHandler = this.gameObject.AddComponent<InputHandler>() as InputHandler;
        inputActionTranslator = new InputActionTranslator(inputHandler, actionBinding);
        resource = resourceObject.GetComponent<ResourceLoader>();
        objectHandler = new ObjectHandler(this.controlHandler, this.resource);
        updateHandler = this.gameObject.AddComponent<UpdateHandler>() as UpdateHandler;
        coaa = new ControlledObjectActionActuator(updateHandler, inputActionTranslator, controlHandler);
        environmentManager = new EnvironmentManager(updateHandler, objectHandler, mainCameraObject);
    }

    public ObjectHandler getObjectHandler()
    {
        return objectHandler;
    }
}
