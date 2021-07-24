using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_DevTools : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) == true)
        {
            GameObject.Find("Player").GetComponent<Player>().OnPilotBonus();
        }
        if (Input.GetKeyDown(KeyCode.U) == true)
        {
            GameObject.Find("Player").GetComponent<Player>().OnRepairDroneBonus();
        }
        if (Input.GetKeyDown(KeyCode.Equals) == true)
        {
            GameObject.Find("Player").GetComponent<Player>().OnComponentBonus(Factory.Dice_Rarity());
        }
        if (Input.GetKeyDown(KeyCode.O) == true)
        {
            int index = Random.Range(1, 5);
            Factory.Create_Deposit(500, 3, Map.SpawnIndexToPosition(index));
        }
    }
}
