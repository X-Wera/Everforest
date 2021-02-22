using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UpdateHandler : MonoBehaviour
{
    public delegate void Tick();
    public event Tick OnTick;

    private ZDepth zDepth;

    private void Start()
    {
        zDepth = gameObject.AddComponent<ZDepth>() as ZDepth;
    }
    private void FixedUpdate()
    {
        if (OnTick != null)
        {
            OnTick();
        }
    }


}
