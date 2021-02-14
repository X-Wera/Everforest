using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitScript : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject resourceObject;

    public ActionBinding actionBinding = new ActionBinding();
    private ControlHandler controlHandler = new ControlHandler();
    private InputActuation inputActuation;
    private InputActionTranslator inputActionTranslator;
    private InputHandler inputHandler;
    private ObjectHandler objectHandler;
    private ResourceLoader resource;

    void Start()
    {
        initCoreComponents();
        TestingMethodKillMeLaterImBeggingYouPLEEAAAASEEEEEEEEEE();
    }

    private void TestingMethodKillMeLaterImBeggingYouPLEEAAAASEEEEEEEEEE()
    {
        // WASD
        actionBinding.bindKeyToAction(KeyCode.W, KeyAction.MoveUp);
        actionBinding.bindKeyToAction(KeyCode.D, KeyAction.MoveRight);
        actionBinding.bindKeyToAction(KeyCode.S, KeyAction.MoveDown);
        actionBinding.bindKeyToAction(KeyCode.A, KeyAction.MoveLeft);

        // ARROW KEYS
        actionBinding.bindKeyToAction(KeyCode.UpArrow, KeyAction.MoveUp);
        actionBinding.bindKeyToAction(KeyCode.RightArrow, KeyAction.MoveRight);
        actionBinding.bindKeyToAction(KeyCode.DownArrow, KeyAction.MoveDown);
        actionBinding.bindKeyToAction(KeyCode.LeftArrow, KeyAction.MoveLeft);

        // MOUSE BUTTONS

        actionBinding.bindMouseButtonToAction(0, MouseAction.PrimaryAction);

        // Creating shitty objects
        objectHandler.createObject("Rat", new Vector3(5, 0, 0));
        objectHandler.createObject("MainCharacter", new Vector3(5, 5, 0), true);
        GameObject obj = objectHandler.createObject("MainCharacter", new Vector3(0, 0, 0), true);

        maincamera.GetComponent<CameraScript>().setFocused(obj);
    }

    private void initCoreComponents()
    {
        inputHandler = this.gameObject.AddComponent<InputHandler>() as InputHandler;
        // The InputConfig Must Be INTITIALIZED AFTER THE INPUT HANDLER!
        inputActionTranslator = this.gameObject.AddComponent<InputActionTranslator>() as InputActionTranslator;

        resource = resourceObject.GetComponent<ResourceLoader>();
        objectHandler = new ObjectHandler(this.controlHandler, this.resource);
        inputActuation = new InputActuation(inputActionTranslator,objectHandler);
    }
}
