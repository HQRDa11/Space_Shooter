using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLoot 
{
    private ModuleData[] m_options;
    public ModuleData[] Options  { get => m_options; }

    public FinalLoot(int level, int score)
    {
        m_options = new ModuleData[3];
        for (int i = 0; i<m_options.Length; i++)
        {
            m_options[i] = Factory.Instance.Module_Factory.Dice_ModuleData(level);
        }
    }
}
