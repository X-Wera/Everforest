using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActuator : MonoBehaviour
{
    public InputHandler inputHandler;
    public ControlHandler controlHandler;

    // Update is called once per frame
    void Update()
    {
        HashSet<GameObject> controlled = controlHandler.getControlledObjects();

        foreach (GameObject o in controlled)
        {
            move(o);
        }

        void move(GameObject o)
        {
            if (o.GetComponent<MainCharacterScript>() != null)
            {
                MainCharacterScript mss = o.gameObject.GetComponent<MainCharacterScript>();
                // If(GameObject is an MainCharacter Object){}
                HashSet<string> input = inputHandler.getKeysPressed();
                if (input.Contains("LeftArrow") || input.Contains("RightArrow") || input.Contains("UpArrow") || input.Contains("DownArrow"))
                {
                    KeyMove k = new KeyMove(o, input, mss.getSpeed());
                }
            }
        }
    }
}