using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Resume()
    {
        GameObject.Find("Game(Clone)").GetComponent<GameManagerScript>().getInputHandler().ClearPressed();
        Destroy(GameObject.Find("InGameMenu(Clone)"));
        Time.timeScale = 1;
    }
}
