using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsPanel
{
    private GameObject m_gameObject; public GameObject GameObject { get => m_gameObject; }
    private List<Button> m_buttons = new List<Button>(); public List<Button> Buttons { get => m_buttons; }
    private GameObject m_textGO; public GameObject TextGO { get => m_textGO; }


    public ButtonsPanel(GameObject parent, string title, int fontSize, string[] buttonsNames, Color32 colorButton, Color32 colorText)
    {

        // > INSTANTIATE Panel

        m_gameObject = new GameObject(
            "Panel Button Choice",
            typeof(RectTransform),
            typeof(CanvasRenderer),
            typeof(Image),
            typeof(VerticalLayoutGroup),
            typeof(ContentSizeFitter),
            typeof(Selectable));
        m_gameObject.transform.SetParent(parent.transform);


        // > INSTANTIATE Text

        m_textGO = new GameObject(
            "Panel Button Choice Text",
            typeof(RectTransform),
            typeof(CanvasRenderer),
            typeof(Text));
        m_textGO.transform.SetParent(m_gameObject.transform);


        // > SET Panel

        /// RectTransform
        RectTransform rect = m_gameObject.GetComponent<RectTransform>();
        rect.anchoredPosition = m_gameObject.transform.position;
        rect.sizeDelta = new Vector2(30, 50); 
        rect.localScale = new Vector3(1, 1, 1); 
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);

        /// Image
        m_gameObject.GetComponent<Image>().color = Color.clear;

        /// VerticalLayoutGroup
        VerticalLayoutGroup vert = m_gameObject.GetComponent<VerticalLayoutGroup>();
        vert.spacing = 5;
        vert.childAlignment = TextAnchor.MiddleCenter;
        vert.childControlWidth = false;
        vert.childControlHeight = false;
        vert.childForceExpandWidth = true;
        vert.childForceExpandHeight = false;

        /// ContentSizeFitter
        ContentSizeFitter cont = m_gameObject.GetComponent<ContentSizeFitter>();
        cont.horizontalFit = ContentSizeFitter.FitMode.MinSize;
        cont.verticalFit = ContentSizeFitter.FitMode.MinSize;

        // > SET Text

        Text text = m_textGO.GetComponent<Text>();
        text.text = title;
        text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        text.fontSize = fontSize;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;
        text.resizeTextForBestFit = true;

        m_textGO.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 30);

        GameObject textShadow = GameObject.Instantiate(m_textGO, m_textGO.transform);
        textShadow.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1, 1);
        textShadow.GetComponent<Text>().color = Color.white;
        textShadow.GetComponent<Text>().resizeTextForBestFit = true;

        // > INSTANTIATE Buttons > Create Buttons.List

        foreach (string str in buttonsNames) m_buttons.Add(new ButtonChoice(m_gameObject, str, colorButton, colorText).ButtonAccess);
        foreach (Button button in m_buttons) button.onClick.AddListener(() => { GameObject.Destroy(m_gameObject); });
    }
}
