using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject EventObject;
    public GameObject maincamera;
    private InputHandler ip;
    float xvel = 0f;
    float yvel = 0f;
    bool lockCamOnCharacter = true;
    float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        EventObject = GameObject.Find("InputHandler");
        maincamera = GameObject.Find("MainCamera");
        ip = EventObject.GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        characterMovement();
    }

    void characterMovement()
    {
        HashSet<string> kp = ip.getKeysPressed();
        foreach (string key in kp)
        {
            if (key.Equals("W") || key.Equals("UpArrow"))
            {
                yvel += speed;
            }
            if (key.Equals("S") || key.Equals("DownArrow"))
            {
                yvel += -speed;
            }
            if (key.Equals("D") || key.Equals("RightArrow"))
            {
                xvel += speed;
            }
            if (key.Equals("A") || key.Equals("LeftArrow"))
            {
                xvel += -speed;
            }
        }
        this.transform.position = this.transform.position + new Vector3(xvel, yvel);

        if (lockCamOnCharacter)
        {
            maincamera.transform.position = maincamera.transform.position + new Vector3(xvel, yvel);
        }

        xvel = 0;
        yvel = 0;
        //print(this.transform.position);
    }
}