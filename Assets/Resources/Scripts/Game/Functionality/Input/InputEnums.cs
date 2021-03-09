using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseAction
{
    NoAction,
    PrimaryAction, PrimaryActionShift, PrimaryActionControl, PrimaryActionAlt, PrimaryActionCommand, PrimaryActionFunction,
    SecondaryAction, SecondaryActionShift, SecondaryActionControl, SecondaryActionAlt, SecondaryActionCommand, SecondaryActionFunction,
    TertiaryAction, TertiaryActionShift, TertiaryActionControl, TertiaryActionAlt, TertiaryActionCommand, TertiaryActionFunction
}
public enum KeyAction
{
    NoAction, MoveUp, MoveDown, MoveRight, MoveLeft,
    Escape
}
public enum MouseButtonPosition
{
    Up, Down, Drag
}
public enum KeyPosition
{
    Up, Down
}