using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Destructible
{

    private HashSet<GameObject> currentlyInReach = new HashSet<GameObject>();
    private GameObject menu;


    private void OnMouseDown()
    {
        //Debug.Log(this + " clicked.");
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            currentlyInReach.Add(collider.gameObject);
            GameObject collidedObject = collider.gameObject;
            if (menu == null)
            {
                menu = createMenu();
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        currentlyInReach.Remove(collider.gameObject);
        if (currentlyInReach.Count == 0)
        {
            gameManager.getObjectHandler().destroyObject(menu);
        }
    }
    private GameObject createMenu()
    {
        GameObject menu = null;
        if (gameManager != null)
            if (gameManager.getObjectHandler() != null)
                menu = gameManager.getObjectHandler().createObject("ShopMenu", this.gameObject.transform.position + new Vector3(0, 0.75f, 0), -1);

        return menu;
    }
}
