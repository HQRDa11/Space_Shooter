using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame_Logic
{
    private GameInfo m_gameInfo;
    private FinalLoot m_finalLoot;
    public FinalLoot FinalLoot { get => m_finalLoot; }
    public GameInfo GameInfo { get => m_gameInfo; }
    public EndGame_Logic()
    {
        m_gameInfo = GameObject.Find("GameInfo").GetComponent<GameInfo>();
        if (m_gameInfo == null )
        {
            Debug.LogWarning(" No GameInfo Object");
        }
        else
        {
            ProfileHandler.Instance.ActiveProfile.Data.UpdateProfile_WithGameResults(m_gameInfo);
            m_finalLoot = new FinalLoot(1, GameInfo.Get_Score());
        }

    }

    public void OnUserChoice(int choice)
    {
        Debug.LogWarning("index " + choice + " on tab length" + m_finalLoot.Options.Length);
        Application_StateMachine.Instance.Get_CurrentState().WaitUserEntry();
        ProfileHandler.Instance.ActiveProfile.SquadronData.AddModule(m_finalLoot.Options[choice]);
        ProfileHandler.Instance.StateSave();
    }
}
