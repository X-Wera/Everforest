﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader : MonoBehaviour
{
    public Texture2D[] textures;
    public HashSet<Sprite> sprites = new HashSet<Sprite>();

    void Start()
    {
        convertAllImagesToSprites();

    }

    Sprite getImage(string nameOfImage)
    {
        foreach (Sprite i in sprites)
        {
            if (i.name.Equals(nameOfImage))
            {
                return i;
            }

        }
        return null;
    }

    void convertAllImagesToSprites()
    {
        //Converts all textures(Images) into sprites. Making their position the center of the sprite.
        foreach (Texture2D i in textures)
        {
            sprites.Add(Sprite.Create(i, new Rect(0, 0, i.width, i.height), new Vector2(0.5f, 0.5f)));
        }
    }
}