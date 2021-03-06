using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProfileHandler : MonoBehaviour
{
    private static ProfileHandler _instance;
    public static ProfileHandler Instance { get => _instance; }

    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";
    [SerializeField] private GameObject m_profileObject;
    private Profile m_activeProfile;
    public Profile ActiveProfile { get => m_activeProfile; }

    private void Awake()
    {
        _instance = this;

        SaveSystem.Init();
        Debug.Log("SaveSystem initialised");
        m_profileObject = GameObject.Find("ActiveProfile");
        m_activeProfile = m_profileObject.GetComponent<Profile>();
        if (m_activeProfile == null)
        {
            Debug.Log("Profile check: No active Profile");
            m_activeProfile = m_profileObject.AddComponent<Profile>();
            m_activeProfile.Data = new ProfileData();
        }
    }
    private class SaveObject
    {
        public ProfileData   profileData;
        public SquadronData squadronData;
    }

    public void ProfileSave()
    {
        Save();
    }
    private void Save()
    {
        // RETRIEVE ACTIVE PRODILE INFOS:
        //Debug.Log("Saving:" + m_activeProfile.ID + "//" + "highScores:" + m_activeProfile.HighScores[0] + "/" + m_activeProfile.HighScores[1]);
        ProfileData profileData = m_activeProfile.Data;
        string newProfileId = profileData.ProfileID;
        int newGameCurrency = profileData.GameCurrency;
        int[] newHighScores = profileData.HighScores;
        int[] newComponents = profileData.Components;
        m_activeProfile.SquadronData.AllMembers[0].Name = profileData.ProfileID;
        SquadronData newSquadronData = m_activeProfile.SquadronData;
        //Debug.LogWarning("IsSquadronData?:" + newSquadronData) ;
        //Debug.LogWarning("IsSquadronDataPlayerName?:" + newSquadronData.Player.name) ;

        //CREATE SAVEOBJECT:
        SaveObject saveObject = new SaveObject
        {
            profileData = profileData,
            squadronData = newSquadronData
        };

        // SAVEOBJECT TO JSON STRING:
        string json = JsonUtility.ToJson(saveObject);

        // SAVE JSON STRING:
        SaveSystem.Save(json);

        Debug.LogWarning("Profile Saved:" + saveObject.profileData.ProfileID);
    }
    public void StateSave()
    {
        Save();
    }

    public bool Load()
    {
        // Load
        string saveString = SaveSystem.LoadMostRecentFile();
        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            switch ( saveObject.profileData != null)
            {
                case true:
                    switch (saveObject.profileData.AppVersion == ApplicationInfo.VERSION)
                    {
                        case true:
                            m_activeProfile.Data = saveObject.profileData;
                            m_activeProfile.SquadronData = saveObject.squadronData;
                            Debug.LogWarning("Profile Loaded:" + m_activeProfile.Data.ProfileID);
                            return true;
                        case false:
                            Debug.LogError("Can't load last profile save ( save version outdated )");
                            break;
                    }
                    break;
                case false:
                    Debug.LogError("No Profile");
                    break;
            }
        }
        else
        {
            Debug.LogWarning("There is no save in directory: " + Application.persistentDataPath + "/Saves/" );
        }
        m_activeProfile.NewProfile();
        return false;
    }

    // The following fncts should be put in a ProfileData class.
    //public void UpdateProfile_WithGameResults( GameInfo info)
    //{
    //    Update_HighScores(info.Get_Score()) ;
    //    Update_TotalComponents(info.Get_lootedComponents());
    //    Save();
    //}
    //public void Update_TotalComponents(int[] lootedComponents)
    //{
    //    if(!m_activeProfile)
    //    {
    //        Debug.LogError("No active profile");
    //    }
    //    for (int i = 0; i<lootedComponents.Length; i++)
    //    {
    //        m_activeProfile.ModifyNumberOf_Components(i, lootedComponents[i]);
    //        //Debug.Log("COmponent " + i + " ok");
    //    }
    //}
    //private void Update_HighScores(int score)
    //{
    //    int[] highScores = new int[10];
    //    for (int i = 0; i < highScores.Length; i++)
    //    {
    //       highScores[i] = m_activeProfile.HighScores[i];
    //    }
    //        int temp = 0;
    //    for (int i = 0; i < highScores.Length; i++)
    //    {
    //        switch (score >= highScores[i])
    //        {
    //            case true:
    //                temp = highScores[i];
    //                highScores[i] = score;
    //                score = temp;
    //                break;
    //        }
    //    }
    //    m_activeProfile.HighScores = highScores;
    //}

}
