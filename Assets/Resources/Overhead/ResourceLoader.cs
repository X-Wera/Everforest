using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    HashSet<Sprite> sprites = new HashSet<Sprite>();

    void Start()
    {
        loadResources();
    }

    void loadResources()
    {
        //Sprite x = Resources.Load<Sprite>("Textures/Icon_2");
    }
}