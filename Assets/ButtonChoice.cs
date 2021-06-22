using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChoice
{
    private Button m_button;
    public Button ButtonAccess { get => m_button; }
    public ButtonChoice(GameObject parent, string name, Color32 colorButton, Color32 colorText)
    {

        // > INSTANTIATE Button

        GameObject button = new GameObject(
            "Button " + name,
            typeof(RectTransform),
            typeof(CanvasRenderer),
            typeof(Image),
            typeof(Button));
        button.transform.SetParent(parent.transform);


        // > INSTANTIATE Text

        GameObject textGO = new GameObject(
            "Button " + name + " Text",
            typeof(RectTransform),
            typeof(CanvasRenderer),
            typeof(Text));
        textGO.transform.SetParent(button.transform);

        
        // > SET Button

        RectTransform rect = button.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(160, 30);
        rect.localScale = new Vector3(1, 1, 1);

        button.GetComponent<Image>().color = colorButton;
        m_button = button.GetComponent<Button>();


        // > SET Text

        /// -Text
        Text text = textGO.GetComponent<Text>();
        text.text = name;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.fontSize = 14;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = colorText;

        /// -Rect
        RectTransform textRect = textGO.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0, 0);
        textRect.anchorMax = new Vector2(1, 1);
        textRect.sizeDelta = new Vector2(0, 0);

    }
}
