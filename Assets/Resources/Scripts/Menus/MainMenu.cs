using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();

        //Only needed in editor not in application. =>
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void optionsMenu()
    {
        Destroy(GameObject.Find("MainMenu(Clone)"));
        MonoBehaviour.Instantiate(GameObject.Find("ResourceObject").GetComponent<ResourceLoader>().getObjectPrefab("OptionsMenu"),
    new Vector3(0, 0, 0), Quaternion.identity);
    }

    public void startGame()
    {
        Destroy(GameObject.Find("MainMenu(Clone)"));
        MonoBehaviour.Instantiate(GameObject.Find("ResourceObject").GetComponent<ResourceLoader>().getObjectPrefab("Game"),
new Vector3(0, 0, 0), Quaternion.identity);
    }
}