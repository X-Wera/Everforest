using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject groundObject;
    private GameObject mainCameraObject;

    private ControlHandler controlHandler;
    private EnvironmentManager environmentManager;
    private InputHandler inputHandler;
    private ObjectHandler objectHandler;
    private ResourceLoader resource;
    private ZDepth zDepth;

    void Start()
    {
        mainCameraObject = GameObject.Find("MainCamera");
        resource = GameObject.Find("ResourceObject").GetComponent<ResourceLoader>();
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

        // Escape
        inputHandler.setBinding(KeyCode.Escape, CharacterAction.Escape);

        // WASD
        inputHandler.setBinding(KeyCode.W, CharacterAction.MoveUp);
        inputHandler.setBinding(KeyCode.D, CharacterAction.MoveRight);
        inputHandler.setBinding(KeyCode.S, CharacterAction.MoveDown);
        inputHandler.setBinding(KeyCode.A, CharacterAction.MoveLeft);

        // ARROW KEYS
        inputHandler.setBinding(KeyCode.UpArrow, CharacterAction.MoveUp);
        inputHandler.setBinding(KeyCode.RightArrow, CharacterAction.MoveRight);
        inputHandler.setBinding(KeyCode.DownArrow, CharacterAction.MoveDown);
        inputHandler.setBinding(KeyCode.LeftArrow, CharacterAction.MoveLeft);

        // MOUSE BUTTONS
        inputHandler.setBinding(KeyCode.Mouse0, CharacterAction.MousePrimary);

    }

    private void initCoreComponents()
    {
        controlHandler = new ControlHandler();
        inputHandler = this.gameObject.AddComponent<InputHandler>() as InputHandler;
        objectHandler = new ObjectHandler(this.controlHandler, this.resource);
        environmentManager = new EnvironmentManager(objectHandler, mainCameraObject);
        zDepth = this.gameObject.AddComponent<ZDepth>() as ZDepth;
    }

    public ObjectHandler getObjectHandler()
    {
        return objectHandler;
    }
    public ControlHandler getControlHandler()
    {
        return controlHandler;
    }
    public InputHandler getInputHandler()
    {
        return inputHandler;
    }
}
