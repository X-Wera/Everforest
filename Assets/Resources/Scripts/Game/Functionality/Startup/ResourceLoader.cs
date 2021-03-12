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
        return null;
    }
}