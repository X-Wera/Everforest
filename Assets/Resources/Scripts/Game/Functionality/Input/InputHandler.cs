using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// CURRENTLY ONLY HANDLES KEY AND MOUSE ACTIONS NO TOUCH, JOYSTICK, ETC...

public class InputHandler : MonoBehaviour
{
    public delegate void MouseDown(int button, Vector2 mousePos);
    public delegate void MouseUp(int button, Vector2 mousePos);
    public delegate void MouseDrag(int button, Vector2 mousePos);
    public delegate void ScrollWheel(Vector2 delta);
    public delegate void KeyDown(KeyCode key);
    public delegate void KeyUp(KeyCode key);
    //public delegate void ContextClick();

    public event MouseDown OnMouseDown;
    public event MouseUp OnMouseUp;
    public event MouseDrag OnMouseDrag;
    public event ScrollWheel OnScrollWheel;
    public event KeyDown OnKeyDown;
    public event KeyUp OnKeyUp;
    //public event ContextClick OnContextClick;

    HashSet<int> mouseButtonsCurrentlyPressed = new HashSet<int>();
    HashSet<KeyCode> keysCurrentlyPressed = new HashSet<KeyCode>();

    void OnGUI()
    {
        Event e = Event.current;

        if (!e.type.Equals(EventType.Repaint) && !e.type.Equals(EventType.Layout) && !e.type.Equals(EventType.Ignore) && !e.type.Equals(EventType.Used))
        {
            //EventModifiers modifiers = e.modifiers;
            //string commandname = e.commandName;
            //int displayindex = e.displayIndex;
            EventType type = e.type;

            if (e.isMouse)
            {
                Vector2 mousePos = e.mousePosition;
                int button = e.button;
                //int clickcount = e.clickCount;

                switch (e.type)
                {
                    case EventType.MouseDown:
                        mouseButtonsCurrentlyPressed.Add(button);
                        if (OnMouseDown != null)
                            OnMouseDown(button, mousePos);
                        break;
                    case EventType.MouseUp:
                        mouseButtonsCurrentlyPressed.Remove(button);
                        if (OnMouseUp != null)
                            OnMouseUp(button, mousePos);
                        break;
                    case EventType.MouseDrag:
                        if (OnMouseDrag != null)
                            OnMouseDrag(button, mousePos);
                        break;
                    case EventType.ScrollWheel:
                        if (OnScrollWheel != null)
                            OnScrollWheel(e.delta);
                        break;
                    default:
                        // Ignore
                        break;
                }

            }
            else if (e.isKey)
            {
                //char character = e.character;
                KeyCode keycode = e.keyCode;
                //bool numeric = e.numeric;

                switch (e.type)
                {
                    case EventType.KeyDown:
                        keysCurrentlyPressed.Add(keycode);
                        if (OnKeyDown != null)
                            OnKeyDown(keycode);
                        break;
                    case EventType.KeyUp:
                        keysCurrentlyPressed.Remove(keycode);
                        if (OnKeyUp != null)
                            OnKeyUp(keycode);
                        break;
                    default:
                        // Ignore
                        break;
                }
            }
            else
            {
                /*
                switch (e.type)
                {
                    case EventType.ExecuteCommand:
                        // A command has been executed.
                        break;
                    case EventType.ValidateCommand:
                        // A command has been validated.
                        break;
                    case EventType.ContextClick:
                        if (OnContextClick != null)
                            OnContextClick();
                        break;
                default:
                        // Ignore
                        break;
            }
            */
                /*
                ***Just in case we want to use anything other than mouse or keys...***

                PointerType pointertype = e.pointerType;
                float pressure = e.pressure;

                ***EventTypes...***

                TouchDown Direct manipulation device(finger, pen) touched the screen.
                TouchUp Direct manipulation device(finger, pen) left the screen.
                TouchMove Direct manipulation device(finger, pen) moved on the screen(drag).
                TouchEnter Direct manipulation device(finger, pen) moving into the window(drag).
                TouchLeave Direct manipulation device(finger, pen) moved out of the window(drag).
                TouchStationary Direct manipulation device(finger, pen) stationary event (long touch down).
                */
            }
    }
    //Debug.Log("Current detected event: " + Event.current);
}

public HashSet<int> getMouseButtonsCurrentlyPressed()
{
    return mouseButtonsCurrentlyPressed;
}
public HashSet<KeyCode> getKeysCurrentlyPressed()
{
    return keysCurrentlyPressed;
}
}