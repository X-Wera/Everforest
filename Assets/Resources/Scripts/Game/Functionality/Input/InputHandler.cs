using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// CURRENTLY ONLY HANDLES KEY AND MOUSE ACTIONS NO TOUCH, JOYSTICK, ETC...

public class InputHandler : MonoBehaviour
{
    public delegate void MouseDown(int button, EventModifiers modifiers, Vector2 mousePos);
    public delegate void MouseUp(int button, EventModifiers modifiers, Vector2 mousePos);
    public delegate void MouseDrag(int button, EventModifiers modifiers, Vector2 mousePoss);
    public delegate void ScrollWheel(Vector2 delta);
    public delegate void KeyDown(KeyCode key, EventModifiers modifiers);
    public delegate void KeyUp(KeyCode key, EventModifiers modifiers);
    //public delegate void ContextClick();

    public event MouseDown OnMouseDown;
    public event MouseUp OnMouseUp;
    public event MouseDrag OnMouseDrag;
    public event ScrollWheel OnScrollWheel;
    public event KeyDown OnKeyDown;
    public event KeyUp OnKeyUp;
    //public event ContextClick OnContextClick;

    HashSet<Tuple<int, EventModifiers>> mouseButtonsCurrentlyPressed = new HashSet<Tuple<int, EventModifiers>>();
    HashSet<Tuple<KeyCode, EventModifiers>> keysCurrentlyPressed = new HashSet<Tuple<KeyCode, EventModifiers>>();

    void OnGUI()
    {
        Event e = Event.current;

        if (!e.type.Equals(EventType.Repaint) && !e.type.Equals(EventType.Layout) && !e.type.Equals(EventType.Ignore) && !e.type.Equals(EventType.Used))
        {
            EventModifiers modifiers = e.modifiers;
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
                        mouseButtonsCurrentlyPressed.Add(new Tuple<int, EventModifiers>(button, modifiers));
                        if (OnMouseDown != null)
                            OnMouseDown(button, modifiers, mousePos);
                        break;
                    case EventType.MouseUp:
                        mouseButtonsCurrentlyPressed.Remove(new Tuple<int, EventModifiers>(button, modifiers));
                        if (OnMouseUp != null)
                            OnMouseUp(button, modifiers, mousePos);
                        break;
                    case EventType.MouseDrag:
                        if (OnMouseDrag != null)
                            OnMouseDrag(button, modifiers, mousePos);
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
                        keysCurrentlyPressed.Add(new Tuple<KeyCode, EventModifiers>(keycode, modifiers));
                        if (OnKeyDown != null)
                            OnKeyDown(keycode, modifiers);
                        break;
                    case EventType.KeyUp:
                        keysCurrentlyPressed.Remove(new Tuple<KeyCode, EventModifiers>(keycode, modifiers));
                        if (OnKeyUp != null)
                            OnKeyUp(keycode, modifiers);
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

    public HashSet<Tuple<int, EventModifiers>> getMouseButtonsCurrentlyPressed()
    {
        return mouseButtonsCurrentlyPressed;
    }
    public HashSet<Tuple<KeyCode, EventModifiers>> getKeysCurrentlyPressed()
    {
        return keysCurrentlyPressed;
    }
}