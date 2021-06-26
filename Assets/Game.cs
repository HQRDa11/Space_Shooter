using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public void OnGameOver()
    {
        GameObject.Find("StateMachine").GetComponent<Application_StateMachine>().stateRequest(ApplicationState_Type.ENDGAME);
    }
}
