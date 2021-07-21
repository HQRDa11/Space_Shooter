using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiElement_ComponentCostsDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public void Display_Costs(int[] cost)
    {
        Text[] AllComponentTexts = gameObject.GetComponentsInChildren<Text>();
        for (int i = 0; i<6;i++)
        {
            AllComponentTexts[i].text = cost[i].ToString();
        }
    }

}
