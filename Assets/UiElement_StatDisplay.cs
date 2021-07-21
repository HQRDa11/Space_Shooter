using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiElement_StatDisplay : MonoBehaviour
{
    private void Start()
    {
        if (this.transform.parent == null)
        {
            Debug.Log("No parent");
            switch (gameObject.transform.parent==null)
            {
                case true:
                    this.gameObject.transform.SetParent(GameObject.FindObjectOfType<UiElement_VerticalGridLayout>().transform);
                    break;
            }
        }
    }
    // Only used to find object in prefab
}
