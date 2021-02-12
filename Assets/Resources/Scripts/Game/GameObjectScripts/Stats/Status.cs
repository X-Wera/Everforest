using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    private bool arrived = true;
    private bool stopped = false;

    public bool getArrived()
    {
        return arrived;
    }

    public void setArrived(bool s)
    {
        arrived = s;
    }
    public bool getStopped()
    {
        return stopped;
    }

    public void setStopped(bool s)
    {
        stopped = s;
    }
}
