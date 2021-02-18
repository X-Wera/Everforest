using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    HashSet<GameObject> currentlyInReach = new HashSet<GameObject>();
    GameObject menu;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        currentlyInReach.Add(collider.gameObject);

        GameObject collidedObject = collider.gameObject;
        //Debug.Log(collidedObject + " touched me!");
        if (menu == null)
        {
            createMenu();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        currentlyInReach.Remove(collider.gameObject);
        if (currentlyInReach.Count == 0)
        {
            Destroy(menu);
            menu = null;
        }
    }

    private void createMenu()
    {
        menu = new GameObject();
        menu.transform.localScale = menu.transform.localScale / 3;
        SpriteRenderer spriteRenderer = menu.AddComponent<SpriteRenderer>() as SpriteRenderer;
        ResourceLoader resource = GameObject.Find("ResourceObject").GetComponent<ResourceLoader>();
        Sprite sprite = resource.getSprite("meat");
        spriteRenderer.sprite = sprite;
        Vector3 offset = new Vector3(0, 1.5f, 0);
        spriteRenderer.transform.position = this.transform.position + offset;

        //menu.AddComponent<meat>() as Sprite;
    }
}
