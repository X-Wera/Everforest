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
        initPlayer();
        removeLoadingScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void removeLoadingScreen()
    {
        var ls = GameObject.Find("LoadingScreen");
        Destroy(ls);
    }

    void initPlayer()
    {

    }

    void initCamera()
    {
        maincamera = GameObject.Find("MainCamera");
        maincamera.SetActive(true);
    }
 
}
