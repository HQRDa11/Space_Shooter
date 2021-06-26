using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_ApplicationState : ApplicationState
{
    private GameObject m_game;

    public Game_ApplicationState(string name)
        : base(name)
    {
        m_type = ApplicationState_Type.GAME;
        m_game = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Game/Game"));
        m_game.name = "Game";
        m_game.transform.SetParent(GameObject.Find("State_Game").transform);

        Factory.Instance.SetInGameObjects_Parent(GameObject.Find("InGameObjects").transform);
    }

    public override void update()
    {
        base.update();
    }

    public override void end()
    {
        // Call Game.save()
        GameObject.Destroy(m_game);
    }

}
