using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHandler : MonoBehaviour
{

    void loadSprite(string filepath)
    {
        Sprite s = Resources.Load(filepath, typeof(Sprite)) as Sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
