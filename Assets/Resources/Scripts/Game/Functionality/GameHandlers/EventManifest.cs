using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManifest : MonoBehaviour
{
    public delegate void ClickAction(Vector3 mp, bool l, bool r, bool m);
    public event ClickAction OnClick;

    public void Click(Vector3 mp,bool l ,bool r ,bool m)
    {
        if (OnClick != null)
        {
            OnClick(mp, l, r, m);
        }
    }
}
