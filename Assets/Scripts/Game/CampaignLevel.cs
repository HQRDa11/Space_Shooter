using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Diffulty { EASY = 1, NORMAL, HARD, HARDCORE, INSANE, GODLIKE, FREE_BRUTALITY }

public class CampaignLevel 
{
    private int _level;
    private int _difficulty;
    private GameObject _bossPrefab;

    public CampaignLevel(int level, Diffulty difficulty, GameObject bossPrefab)
    {
        _level = level;
        _difficulty = (int)difficulty;
        _bossPrefab = bossPrefab;
    }
}
