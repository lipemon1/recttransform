using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomRectTransform
{
    public static Vector2 DISABLE_POS = new Vector2(-5000f, -5000f);
    public static Dictionary<int, CustomRect> rectDic = new Dictionary<int, CustomRect>();
    
    public class CustomRect
    {
        private bool _active;
        public RectTransform RectTransform;

        public CustomRect(RectTransform rectTransform, bool value = true)
        {
            RectTransform = rectTransform;

            _active = true;
            SetActive(value);

            rectTransform.gameObject.SetActive(true);
        }

        public void SetActive(bool value)
        {
            if (_active == value)
            {
                Debug.Log($"State will not change because it's the same: Cur[{_active}] / New[{value}]");
                return;
            }

            Debug.Log("Changing rect value and pos");
            _active = value;
            RectTransform.anchoredPosition = value ? RectTransform.anchoredPosition - DISABLE_POS : RectTransform.anchoredPosition + DISABLE_POS;
        }
    }

    private static void ToggleRectTransform(RectTransform rectTransform, bool value)
    {
        int rectId = rectTransform.GetInstanceID();

        if (rectDic.TryGetValue(rectId, out CustomRect customRect))
        {
            Debug.Log("Custom Rect found.");
            customRect.SetActive(value);
        }
        else
        {
            Debug.Log("New Custom Rect");
            rectDic.Add(rectId, new CustomRect(rectTransform, value));
        }
    }

    public static void ToggleUIObject(this RectTransform rectTransform, bool visibility)
    {
        ToggleRectTransform(rectTransform, visibility);
    }
}