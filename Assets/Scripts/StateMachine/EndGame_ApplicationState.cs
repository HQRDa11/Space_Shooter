using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame_ApplicationState : ApplicationState
{
    public EndGame_ApplicationState(string name)
        : base(name)
    {
        m_type = ApplicationState_Type.ENDGAME;
        m_UI = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_States/UI_EndGame"));
        m_UI.transform.SetParent(GameObject.Find("State_EndGame").gameObject.transform);

        GameObject scoreGO = GameObject.Find("Score");
        m_UI.transform.GetChild(0).GetComponent<Text>().text =
            "Game Over \n" +
            "\n" +
            "\n" +
            "\n" +
            "Score : " + scoreGO.transform.GetChild(0).name + "\n" +
            "Loots : " + "\n" +
            "RewardChestOpening : ";
        GameObject.Destroy(scoreGO);
    }

    public override void update()
    {
        base.update();
        //Debug.Log("I am state." + m_type + " and I just updated! ");
        if (Input.GetMouseButtonDown(0))
        {
            m_stateMachine.stateRequest(ApplicationState_Type.MAINMENU);
        }
    }

    public override void end()
    {
        GameObject.Destroy(m_UI);
        Debug.Log("state" + m_type + " ending! ");
    }
}
