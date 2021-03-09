using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOptionsScript : MonoBehaviour
{
    public void MainMenu()
    {
        Destroy(GameObject.Find("OptionsMenu(Clone)"));
        MonoBehaviour.Instantiate(GameObject.Find("ResourceObject").GetComponent<ResourceLoader>().getObjectPrefab("MainMenu"),
    new Vector3(0, 0, 0), Quaternion.identity);
    }
}
