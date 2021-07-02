using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ProfileHandler : MonoBehaviour
{
    private const string SAVE_SEPARATOR = "#SAVE-VALUE#";
    [SerializeField] private GameObject m_profileObject;
    private Profile m_activeProfile;
    private void Start()
    {
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
        Debug.Log("Saving:" + m_activeProfile.ID + "//" + "highScores:" + m_activeProfile.HighScores[0] + "/" + m_activeProfile.HighScores[1]);
        string profileID = m_activeProfile.ID;
        int gameCurrency = m_activeProfile.GameCurrency;
        int[] highScores = m_activeProfile.HighScores;

        SaveObject saveObject = new SaveObject
        {
            _profileID = profileID,
            _gameCurrency = gameCurrency,
            _highScores = highScores

        };
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
        Debug.LogWarning("Game Saved");

    }

    private void Load()
    {
        // Load
        string saveString = SaveSystem.LoadMostRecentFile();
        if (saveString != null)
        {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            m_activeProfile.ID = saveObject._profileID;
            m_activeProfile.GameCurrency = saveObject._gameCurrency;
            m_activeProfile.HighScores = saveObject._highScores;
            Debug.LogWarning("Loaded Profile" + saveString + " profile datas:" + m_activeProfile.ID + "/" + m_activeProfile.GameCurrency + "/" + m_activeProfile.HighScores[0] + m_activeProfile.HighScores[1]);
        }

        else
        {
            Debug.LogError("No save");
        }
    }

    private class SaveObject
    {
        public string _profileID;
        public int _gameCurrency;
        public int[] _highScores;
    }

    public void UpdateProfile_WithGameResults( GameInfo info)
    {
        Update_HighScores(info.Get_Score()) ;
        Save();
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
