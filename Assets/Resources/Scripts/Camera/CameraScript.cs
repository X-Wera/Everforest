using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject currenltyFocusedObject;

    void Update()
    {
        if (currenltyFocusedObject != null)
        {
            this.transform.position = currenltyFocusedObject.transform.position;
        }
    }

    public void setFocused(GameObject o)
    {
        currenltyFocusedObject = o;
    }

    public GameObject getFocused()
    {
        return currenltyFocusedObject;
    }
}
