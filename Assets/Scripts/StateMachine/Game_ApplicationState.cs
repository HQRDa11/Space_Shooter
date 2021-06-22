using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_ApplicationState : ApplicationState
{

    public Game_ApplicationState(string name)
        : base(name)
    {
        m_type = ApplicationState_Type.GAME;
    }

    public override void update()
    {
        base.update();
    }

    public override void end()
    {
        // Call Game.save()
    }

}
