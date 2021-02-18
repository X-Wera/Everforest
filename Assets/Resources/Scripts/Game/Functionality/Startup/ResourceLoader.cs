using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Exception = System.Exception;

public class ResourceLoader : MonoBehaviour
{
    public GameObject[] EverForestObjects;

    public GameObject getObjectPrefab(string nameOfObject)
    {
        foreach (GameObject i in EverForestObjects)
            if (i.name.Equals(nameOfObject))
                return i;
        throw new Exception("FAILED:" + nameOfObject + " does Not Exist In EverForestObjects! Failed to create object." + System.Environment.NewLine
                          + "Create Object Prefab and add it to the ResourceObject.EverForestObjects Array through Unitys GUI " + System.Environment.NewLine
                          + this);
    }

    public Texture2D[] Textures;

    public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    void Start()
    {
        convertAllImagesToSprites();
    }

    public Sprite getSprite(string nameOfImage)
    {
        foreach (KeyValuePair<string, Sprite> kvp in sprites)
        {
            if (kvp.Key == (nameOfImage))
                return kvp.Value;
        }

        throw new Exception(nameOfImage + " Does Not Exist In Textures!");
    }

    private void convertAllImagesToSprites()
    {
        //Converts all textures(Images) into sprites. Making their position the center of the sprite.
        foreach (Texture2D i in Textures)
        {
            sprites.Add(i.name, Sprite.Create(i, new Rect(0, 0, i.width, i.height), new Vector2(0.5f, 0.5f)));

        }
    }

}