using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitScript : MonoBehaviour
{
    public GameObject maincamera;

    // Start is called before the first frame update
    void Start()
    {
        initCamera();
        createObject();
        removeLoadingScreen();

    }

    void createObject()
    {
        TreeObject t = new TreeObject();
    }

    void removeLoadingScreen()
    {
        var ls = GameObject.Find("LoadingScreen");
        Destroy(ls);
    }

    void initCamera()
    {
        maincamera = GameObject.Find("MainCamera");
        maincamera.SetActive(true);
    }
 
}
