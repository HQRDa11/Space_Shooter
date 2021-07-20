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
    public ProfileData Data { get { return m_profileData; } set { m_profileData = value; Debug.LogWarning("profile data new value"); } }

    private void Awake()
    {
        m_profileData = new ProfileData();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_squadronData = new SquadronData("Unnamed");
    }

    public void ResetProfile()
    {
        Debug.LogWarning("Profile reset");
        m_profileData = new ProfileData();
        m_squadronData = new SquadronData(m_profileData.ProfileID);
    }

    public void ModifyNumberOf_Components( int rarityIndex, int modifier)
    {
        m_profileData.Components[rarityIndex] += modifier;
    }
}
