using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverForestGameObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getLocation()
    {
        return this.transform.position;
    }

    public void setLocation(Vector3 v)
    {
        this.transform.position = v;
    }
}
