using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_ApplicationState : ApplicationState
{
    public Upgrade_ApplicationState(string name)
        : base(name)
    {
        m_type = ApplicationState_Type.UPGRADE;
        Instantiate_UI();
    }

    private void Instantiate_UI()
    {
        m_UI = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_States/UI_Upgrade"));
        m_UI.transform.SetParent(GameObject.Find("State_Upgrade").gameObject.transform);
    }

    public override void update()
    {
        base.update();
        //Debug.Log("I am state." + m_type + " and I just updated! ");
        if (Input.GetMouseButtonDown(0))
        {
            m_stateMachine.stateRequest(ApplicationState_Type.PREPARE);
        }
    }

    public override void end()
    {
        Save();
        GameObject.Destroy(m_UI);
        Debug.Log("state" + m_type + " ending! ");
    }

    public override float GetMainThemeSchedule()
    {
        return 18.3f;
    }

    private void Save()
    {
        // here save
    }
}