using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class BindingActions : MonoBehaviour
{
    HashSet<string> BoundInputs = new HashSet<string>();
    Dictionary<Action, HashSet<string>> Actions = new Dictionary<Action, HashSet<string>>();
}
