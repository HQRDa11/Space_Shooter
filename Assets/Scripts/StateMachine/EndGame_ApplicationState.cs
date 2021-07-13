using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame_ApplicationState : ApplicationState
{
    private GameInfo m_gameInfo;
    public EndGame_ApplicationState(string name)
        : base(name)
    {
        m_type = ApplicationState_Type.ENDGAME;
        Instantiate_UI();
        m_gameInfo = GameObject.Find("GameInfo").GetComponent<GameInfo>() ;
        if (m_gameInfo == null)
        {
            Debug.LogWarning(" No GameInfo Object");
        }
        GameObject.Find("ProfileHandler").GetComponent<ProfileHandler>().UpdateProfile_WithGameResults(m_gameInfo);
        Display_GameInfo();
    }

    private void Instantiate_UI()
    {
        m_UI = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_States/UI_EndGame"));
        m_UI.transform.SetParent(GameObject.Find("State_EndGame").gameObject.transform);
    }

    private void Display_GameInfo()
    {
        m_gameInfo = GameObject.Find("GameInfo").GetComponent<GameInfo>() ;
        m_UI.transform.GetChild(0).GetComponent<Text>().text =
            "Game Over \n" +
            "\n" +
            "\n" +
            "\n" +
            "Score : " + m_gameInfo.Get_Score() + "\n" +
            "Last Wave : " + "\n" +
            "Loots : " + "\n" +
            "RewardChestOpening : ";
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
        GameObject.Destroy(m_gameInfo.gameObject);
        GameObject.Destroy(m_UI);
        Debug.Log("state" + m_type + " ending! ");
    }

    public override int GetMainThemeSchedule()
    {
        return 279;
    }
}
