using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHandler : MonoBehaviour
{
    public delegate void Tick();
    public event Tick OnTick;

    private void Update()
    {
        if (OnTick != null)
        {
            OnTick();
        }
    }
}
