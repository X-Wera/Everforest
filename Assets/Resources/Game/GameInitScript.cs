using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitScript : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject ResourceObject;

    public ObjectHandler objectHandler;
    public InputHandler inputHandler;

    // Start is called before the first frame update
    void Start()
    {
        initCoreComponents();
    }

    // INITALIZATION
    void initCoreComponents()
    {
        objectHandler = this.gameObject.AddComponent<ObjectHandler>() as ObjectHandler;
        inputHandler = this.gameObject.AddComponent<InputHandler>() as InputHandler;
    }
}
