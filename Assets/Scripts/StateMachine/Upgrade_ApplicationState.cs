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
        ProfileHandler.Instance.Load();
    }

    private void Instantiate_UI()
    {
        m_UI = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI_States/UI_Upgrade"));
        m_UI.transform.SetParent(GameObject.Find("State_Upgrade").gameObject.transform);
    }

    public override void update()
    {
        base.update();
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
        ProfileHandler.Instance.StateSave();
    }
    public override ApplicationState_Type Next()
    {
        return ApplicationState_Type.NULL;
    }
    public override ApplicationState_Type Previous()
    {
        return ApplicationState_Type.PREPARE;
    }
}