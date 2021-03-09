using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverForestObject : MonoBehaviour
{
    // Added to Z Axis after ZY Depth is calculated
    public float altitude { get; set; }

    // weight/mass
    public float getWeight()
    {
        return GetComponent<Rigidbody>().mass;
    }
    public void setWeight(float f)
    {
        GetComponent<Rigidbody>().mass = f;
    }
}
