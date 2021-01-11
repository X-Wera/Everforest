using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{

    // OBJECT ACTIONS
    void createObject()
    {

    }

    void destroyObject(EverForestGameObject e)
    {
        Destroy(e);
    }

    void getObjectLocation(EverForestGameObject e)
    {
        e.getLocation();
    }
}
