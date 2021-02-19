using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtificialAxis : MonoBehaviour
{

    double aAxis = 0;

    public void set(double f)
    {
        aAxis = f;
    }

    public double get()
    {
        return aAxis;
    }
}
