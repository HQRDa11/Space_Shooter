using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_ApplicationState : ApplicationState
{

    public Game_ApplicationState()
        : base()
    {
        m_type = ApplicationState_Type.GAME;
    }

    public override void update()
    {
        base.update();

        //Debug.Log("I am state." + m_type + " and I just updated! ");
    }

    public override void end()
    {
        // Call Game.save()
    }

}
