using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Color32 randomColor32()
    {
        return new Color32(
        System.Convert.ToByte(Random.Range(0, 255)),
        System.Convert.ToByte(Random.Range(0, 255)),
        System.Convert.ToByte(Random.Range(0, 255)),
        255
    );

    }
    public Color randomColor()
    {
        // Color version
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }
}
