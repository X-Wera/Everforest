using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitScript : MonoBehaviour
{
    public GameObject maincamera;

    public ResourceLoader resourceLoader;
    public ObjectHandler objectHandler;
    public SpriteHandler spriteHandler;
    public InputHandler inputHandler;

    // Start is called before the first frame update
    void Start()
    {
        initCoreComponents();
        initCamera();
        removeLoadingScreen();

    }

    // INITALIZATION
    void initCoreComponents()
    {
        resourceLoader = this.gameObject.AddComponent<ResourceLoader>() as ResourceLoader;
        objectHandler = this.gameObject.AddComponent<ObjectHandler>() as ObjectHandler;
        spriteHandler = this.gameObject.AddComponent<SpriteHandler>() as SpriteHandler;

        inputHandler = this.gameObject.AddComponent<InputHandler>() as InputHandler;
    }

    void initCamera()
    {
        maincamera = GameObject.Find("MainCamera");
        maincamera.SetActive(true);
    }

    void removeLoadingScreen()
    {
        var ls = GameObject.Find("LoadingScreen");
        Destroy(ls);
    }
}
