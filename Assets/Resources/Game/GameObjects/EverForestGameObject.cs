using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverForestGameObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    //SPRITES
    public void setSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    //LOCATION
    public Vector3 getLocation()
    {
        return this.transform.position;
    }

    public void setLocation(Vector3 v)
    {
        this.transform.position = v;
    }
}
