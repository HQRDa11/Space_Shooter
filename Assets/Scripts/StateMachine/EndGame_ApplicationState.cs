using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame_ApplicationState : ApplicationState
{
    private EndGame_Logic m_endGame_logic;

    public EndGame_ApplicationState(string name)
        : base(name)
    {
        m_type = ApplicationState_Type.ENDGAME;
        m_endGame_logic = new EndGame_Logic();
        m_waitUserEntry = false;
        Instantiate_UI(m_endGame_logic);
    }

    private void Instantiate_UI(EndGame_Logic logic)
    {
        m_UI = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_States/UI_EndGame"));
        m_UI.transform.SetParent(GameObject.Find("State_EndGame").gameObject.transform);
        m_UI.GetComponent<UI_EndGame>().Initialise(logic);
    }

    public override void update()
    {
        base.update();
        switch (m_waitUserEntry)
        {
            case true:
                switch(Input.GetMouseButtonDown(0))
                {
                    case true:
                        ProfileHandler.Instance.StateSave();
                        m_stateMachine.stateRequest(ApplicationState_Type.PREPARE);
                        break;
                    case false:
                        break;
                }
                return;
            case false:
                return;
        }
    }

    public override void end()
    {
        GameObject.Destroy(m_endGame_logic.GameInfo.gameObject);
        GameObject.Destroy(m_UI);
        Debug.Log("state" + m_type + " ending! ");
    }

    public override float GetMainThemeSchedule()
    {
        return 279;
    }

    public override void WaitUserEntry()
    {
        base.WaitUserEntry();
    }
}
