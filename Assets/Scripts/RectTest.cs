using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTest : MonoBehaviour
{
    public bool Value;
    public RectTransform Target;

    [ContextMenu("Toggle Object")]
    public void ToggleObject()
    {
        Target.ToggleUIObject(Value);
    }
}
