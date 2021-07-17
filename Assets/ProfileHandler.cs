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

    private void Start()
    {
        _instance = this;

        SaveSystem.Init();

        m_profileObject = GameObject.Find("ActiveProfile");
        m_activeProfile = m_profileObject.GetComponent<Profile>();
        if (m_activeProfile == null)
        {
            m_activeProfile = m_profileObject.AddComponent<Profile>();
            Debug.Log("error here");
        }
        switch(Load()) { case false: m_activeProfile.ResetProfile(); break; }
    }
    private class SaveObject
    {
        public string applicationVersion;
        public string profileID;
        public int gameCurrency;
        public int[] highScores;
        public int[] components;
        public SquadronData squadronData;
    }
    private void Save()
    {
        // RETRIEVE ACTIVE PRODILE INFOS:
        //Debug.Log("Saving:" + m_activeProfile.ID + "//" + "highScores:" + m_activeProfile.HighScores[0] + "/" + m_activeProfile.HighScores[1]);
        string newProfileId = m_activeProfile.ID;
        int newGameCurrency = m_activeProfile.GameCurrency;
        int[] newHighScores = m_activeProfile.HighScores;
        int[] newComponents = m_activeProfile.TotalComponents;
        SquadronData newSquadronData = m_activeProfile.SquadronData;
        //Debug.LogWarning("IsSquadronData?:" + newSquadronData) ;
        //Debug.LogWarning("IsSquadronDataPlayerName?:" + newSquadronData.Player.name) ;

        //CREATE SAVEOBJECT:
        SaveObject saveObject = new SaveObject
        {
            applicationVersion = ApplicationInfo.VERSION,
            profileID = newProfileId,
            gameCurrency = newGameCurrency,
            highScores = newHighScores,
            components = newComponents,
            squadronData = newSquadronData
        };

        // SAVEOBJECT TO JSON STRING:
        string json = JsonUtility.ToJson(saveObject);

        // SAVE JSON STRING:
        SaveSystem.Save(json);

        Debug.LogWarning("Profile Saved");
    }
    private bool Load()
    {
        // Load
        string saveString = SaveSystem.LoadMostRecentFile();
        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            switch (saveObject.applicationVersion == ApplicationInfo.VERSION)
            {
                case true:
                    m_activeProfile.ID = saveObject.profileID;
                    m_activeProfile.GameCurrency = saveObject.gameCurrency;
                    m_activeProfile.HighScores = saveObject.highScores;
                    m_activeProfile.TotalComponents = saveObject.components;
                    m_activeProfile.SquadronData = saveObject.squadronData;
                    Debug.LogWarning("Profile Loaded");
                    return true;
                case false:
                    Debug.LogError("Can't load last profile save ( save version outdated ).");
                    return false;
            }
        }
        else
        {
            Debug.LogError("There is no save in directory: " + Application.persistentDataPath + "/Saves/" );
        }
        return false;
    }
    public void UpdateProfile_WithGameResults( GameInfo info)
    {
        Update_HighScores(info.Get_Score()) ;
        Update_TotalComponents(info.Get_lootedComponents());
        Save();
    }
    public void Update_TotalComponents(int[] lootedComponents)
    {
        if(!m_activeProfile)
        {
            Debug.LogError("No active profile");
        }
        for (int i = 0; i<lootedComponents.Length; i++)
        {
            m_activeProfile.ModifyNumberOf_Components(i, lootedComponents[i]);
            //Debug.Log("COmponent " + i + " ok");
        }
    }
    private void Update_HighScores(int score)
    {
        int[] highScores = new int[10];
        for (int i = 0; i < highScores.Length; i++)
        {
           highScores[i] = m_activeProfile.HighScores[i];
        }
            int temp = 0;
        for (int i = 0; i < highScores.Length; i++)
        {
            switch (score >= highScores[i])
            {
                case true:
                    temp = highScores[i];
                    highScores[i] = score;
                    score = temp;
                    break;
            }
        }
        m_activeProfile.HighScores = highScores;
    }
    private void NewProfile()
    {
        m_activeProfile.ResetProfile();
    }
}
