using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Resume()
    {
        Destroy(GameObject.Find("InGameMenu(Clone)"));
        Time.timeScale = 1;
    }
}
