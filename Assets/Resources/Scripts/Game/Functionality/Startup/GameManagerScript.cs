using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject mousePosObject;
    private GameObject resourceObject;

    public ActionBinding actionBinding;
    private ControlHandler controlHandler;
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
    }

    private void TestingMethodKillMeLaterImBeggingYouPLEEAAAASEEEEEEEEEE()
    {
        // WASD
        actionBinding.bindKeyToAction(KeyCode.W, EventModifiers.None, KeyAction.MoveUp);
        actionBinding.bindKeyToAction(KeyCode.D, EventModifiers.None, KeyAction.MoveRight);
        actionBinding.bindKeyToAction(KeyCode.S, EventModifiers.None, KeyAction.MoveDown);
        actionBinding.bindKeyToAction(KeyCode.A, EventModifiers.None, KeyAction.MoveLeft);

        // ARROW KEYS
        actionBinding.bindKeyToAction(KeyCode.UpArrow, EventModifiers.None, KeyAction.MoveUp);
        actionBinding.bindKeyToAction(KeyCode.RightArrow, EventModifiers.None, KeyAction.MoveRight);
        actionBinding.bindKeyToAction(KeyCode.DownArrow, EventModifiers.None, KeyAction.MoveDown);
        actionBinding.bindKeyToAction(KeyCode.LeftArrow, EventModifiers.None, KeyAction.MoveLeft);

        // MOUSE BUTTONS
        actionBinding.bindMouseButtonToAction(0, EventModifiers.None, MouseAction.PrimaryAction);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.Shift, MouseAction.PrimaryActionShift);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.Control, MouseAction.PrimaryActionControl);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.Alt, MouseAction.PrimaryActionAlt);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.Command, MouseAction.PrimaryActionCommand);
        actionBinding.bindMouseButtonToAction(0, EventModifiers.FunctionKey, MouseAction.PrimaryActionFunction);

        // Creating shitty objects
        objectHandler.createObject("Rat", new Vector3(5, 0, 0));
        objectHandler.createObject("MainCharacter", new Vector3(5, 5, 0), true);
        GameObject obj = objectHandler.createObject("MainCharacter", new Vector3(0, 0, 0), true);

        maincamera.GetComponent<CameraScript>().setFocused(obj);
    }

    private void initCoreComponents()
    {
        resourceObject = GameObject.Find("ResourceObject");
        if (resourceObject == null)
            throw new Exception("THE RESOURCE OBJECT DOES NOT EXIST! None of Everforests resources can be referenced (or loaded) without an existing ResourceObject. " + System.Environment.NewLine
                + this);

        updateHandler = this.gameObject.AddComponent<UpdateHandler>() as UpdateHandler;
        actionBinding = new ActionBinding();
        controlHandler = new ControlHandler();
        inputHandler = this.gameObject.AddComponent<InputHandler>() as InputHandler;
        inputActionTranslator = new InputActionTranslator(inputHandler, actionBinding);
        resource = resourceObject.GetComponent<ResourceLoader>();
        objectHandler = new ObjectHandler(this.controlHandler, this.resource);
        coaa = new ControlledObjectActionActuator(updateHandler, inputActionTranslator, controlHandler);
    }
}
