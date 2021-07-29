using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    [SerializeReference]
    private SquadronData m_squadronData;
    public SquadronData SquadronData { get { return m_squadronData; } set { m_squadronData = value; } }

    [SerializeField]
    private ProfileData m_profileData;
    public ProfileData Data { get { return m_profileData; } set { m_profileData = value; /*Debug.LogWarning("- setting new value to ProfileData");*/ } }

    private void Awake()
    {
        //ResetProfile();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_squadronData = new SquadronData("Unnamed");
    }

    public void NewProfile()
    {
        m_profileData = new ProfileData();
        m_squadronData = new SquadronData(m_profileData.ProfileID);
        Debug.LogWarning("New profile created");
    }

    public void ModifyNumberOf_Components(int rarityIndex, int modifier)
    {
        m_profileData.Components[rarityIndex] += modifier;
    }

    public bool TryCost(int[] cost)
    {
        for (int i = 0; i<cost.Length; i++)
        {
            switch( cost[i]>Data.Components[i])
            {
                case true:
                    Debug.Log("Not enough components");
                    return false;
            }
        }
        return true;
    }
    public bool SpendComponent(int[] cost)
    {
        switch (TryCost(cost))
        {
            case true:
                for (int i = 0; i < cost.Length; i++)
                {
                    Data.Components[i] -= cost[i];
                }
                return true;
            case false:
                Debug.LogWarning("Error : Not enough components");
                return false;
        }
    }


}
