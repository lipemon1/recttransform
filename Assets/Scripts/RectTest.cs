using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTest : MonoBehaviour
{
    public int IndexToChange;
    public bool Value;

    [Space]
    public List<RectTransform> rectTransforms = new List<RectTransform>();

    [ContextMenu("Toggle Object")]
    public void ToggleObject()
    {
        rectTransforms[IndexToChange].ToggleUIObject(Value);
    }
}
