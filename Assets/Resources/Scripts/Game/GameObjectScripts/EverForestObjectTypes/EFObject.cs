using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EverForestObject : MonoBehaviour
{
    protected GameManagerScript gameManager;
    // Added to Z Axis after ZY Depth is calculated
    public float altitude { get; set; }

    public float getWeight()
    {
        if (GetComponent<Rigidbody>())
            return GetComponent<Rigidbody>().mass;
        else
            return 0;
    }
    public void setWeight(float f)
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().mass = f;
        }
    }

    private void Start()
    {
        gameManager = GameObject.Find("Game(Clone)").GetComponent<GameManagerScript>();
    }


}
