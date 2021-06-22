using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationState 
{
    protected ApplicationState_Type m_type;
    public ApplicationState_Type Type { get {return m_type; } }

    public ApplicationState()
    {
       
    }
    
    public virtual void update()
    {
        //Debug.Log("state." + m_type + " update...");
    }

    public virtual void end()
    {
        //Debug.Log("state." + m_type + " ending...");
    }
}
