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
            this.transform.position = new Vector3(currenltyFocusedObject.transform.position.x, currenltyFocusedObject.transform.position.y, this.transform.position.z);
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
