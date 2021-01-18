using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitScript : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject resourceObject;

    ResourceLoader resource;


    InputHandler inputHandler;
    InputActuator inputActuator;
    ControlHandler controlHandler;
    ObjectHandler objectHandler;

    // Start is called before the first frame update
    void Start()
    {
        initCoreComponents();
        GameObject obj = objectHandler.createObject("MainCharacter", new Vector3(0, 0, 0), true);
        maincamera.GetComponent<CameraScript>().setFocused(obj);


    }

    // INITALIZATION
    void initCoreComponents()
    {
        controlHandler = this.gameObject.AddComponent<ControlHandler>() as ControlHandler;
        inputHandler = this.gameObject.AddComponent<InputHandler>() as InputHandler;

        inputActuator = this.gameObject.AddComponent<InputActuator>() as InputActuator;
        inputActuator.inputHandler = this.inputHandler;
        inputActuator.controlHandler = this.controlHandler;

        objectHandler = this.gameObject.AddComponent<ObjectHandler>() as ObjectHandler;
        objectHandler.controlHandler = this.controlHandler;

        resource = resourceObject.GetComponent<ResourceLoader>();
        objectHandler.resource = this.resource;

    }
}
