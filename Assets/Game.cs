using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private ScoreSystem m_scoreSystem;
    private GameInfo m_gameInfo;

    private void Start()
    {
        m_gameInfo = new GameObject("GameInfo").AddComponent<GameInfo>();
        m_gameInfo.transform.SetParent(GameObject.Find("ActiveProfile").transform);
        m_scoreSystem = GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>();
    }


    public void OnGameOver()
    {
        Save_CurrentGame_Informations();
        GameObject.Find("StateMachine").GetComponent<Application_StateMachine>().stateRequest(ApplicationState_Type.ENDGAME);
    }

    private void Save_CurrentGame_Informations()
    {
        m_gameInfo.Save((int)m_scoreSystem.CurrentScore);
    }
}
