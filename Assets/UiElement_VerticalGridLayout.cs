using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiElement_VerticalGridLayout : MonoBehaviour
{
    public void Reset_AllElements()
    {
        UiElement_StatDisplay[] AllChilds = GetComponentsInChildren<UiElement_StatDisplay>();
        for (int i = 0; i < AllChilds.Length; i++) { GameObject.Destroy(AllChilds[i].gameObject); }
    }
}
