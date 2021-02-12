using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitScript : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject resourceObject;

    ControlHandler controlHandler;

    ResourceLoader resource;
    InputHandler inputHandler;

    ObjectHandler objectHandler;

    // Start is called before the first frame update
    void Start()
    {

        initCoreComponents();

        // Init Main Character
        objectHandler.createObject("Rat", new Vector3(5, 0, 0));
        objectHandler.createObject("MainCharacter", new Vector3(5, 5, 0), true);
        GameObject obj = objectHandler.createObject("MainCharacter", new Vector3(0, 0, 0), true);
        
        maincamera.GetComponent<CameraScript>().setFocused(obj);


    }

    // INITALIZATION
    void initCoreComponents()
    {


        
        objectHandler = this.gameObject.AddComponent<ObjectHandler>() as ObjectHandler;
        controlHandler = this.gameObject.AddComponent<ControlHandler>() as ControlHandler;
        objectHandler.controlHandler = this.controlHandler;

        resource = resourceObject.GetComponent<ResourceLoader>();
        objectHandler.resource = this.resource;

        inputHandler = this.gameObject.AddComponent<InputHandler>() as InputHandler;
        inputHandler.addControlHandler(controlHandler);
        inputHandler.addObjectHandler(objectHandler);





    }
}
