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
        Load();

    }

    // Update is called once per frame
    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.S))
        //{
        //    Save();
        //}       
        //else if(Input.GetKeyDown(KeyCode.L))
        //{
        //    Load();
        //}
    }

    private void Save()
    {
        // Save
        //Debug.Log("Saving:" + m_activeProfile.ID + "//" + "highScores:" + m_activeProfile.HighScores[0] + "/" + m_activeProfile.HighScores[1]);
        string profileID = m_activeProfile.ID;
        int gameCurrency = m_activeProfile.GameCurrency;
        int[] highScores = m_activeProfile.HighScores;
        int[] components = m_activeProfile.TotalComponents;

        SaveObject saveObject = new SaveObject
        {
            _ApplicationVersion = ApplicationInfo.VERSION,
            _profileID = profileID,
            _gameCurrency = gameCurrency,
            _highScores = highScores,
            _components = components
        };
        string json = JsonUtility.ToJson(saveObject);
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
            switch (saveObject._ApplicationVersion == ApplicationInfo.VERSION)
            {
                case true:
                    m_activeProfile.ID = saveObject._profileID;
                    m_activeProfile.GameCurrency = saveObject._gameCurrency;
                    m_activeProfile.HighScores = saveObject._highScores;
                    m_activeProfile.TotalComponents = saveObject._components;
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

    private class SaveObject
    {
        public string _ApplicationVersion;
        public string _profileID;
        public int _gameCurrency;
        public int[] _highScores;
        public int[] _components;
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
}
