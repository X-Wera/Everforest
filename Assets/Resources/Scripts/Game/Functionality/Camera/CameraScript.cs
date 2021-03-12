using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject currenltyFocusedObject { get; set; }

    void Update()
    {
        if (currenltyFocusedObject != null)
        {
            this.transform.position = new Vector3(currenltyFocusedObject.transform.position.x, currenltyFocusedObject.transform.position.y, this.transform.position.z);
        }
    }
}
