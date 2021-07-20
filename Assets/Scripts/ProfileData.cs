using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileData
{
    [SerializeField]
    private string m_appVersion;
    public string AppVersion { get=>m_appVersion; }
    [SerializeField]
    private string m_profileID;
    public string ProfileID { get => m_profileID; }
    [SerializeField]
    private int m_gameCurrency;
    public int GameCurrency { get=>m_gameCurrency;}

    [SerializeField]
    private int[] m_highScores;
    public int[] HighScores { get=>m_highScores; set { m_highScores = value; } }
    [SerializeField]
    private int[] m_allComponents;
    public int[] Components { get => m_allComponents; }

    public ProfileData()
    {
        //Debug.LogWarning("New default ProfileData");
        m_appVersion = ApplicationInfo.VERSION;
        m_profileID = "noID";
        m_gameCurrency = 0;
        m_highScores = new int[10];
        m_allComponents = new int[6];
    }

    public void UpdateProfile_WithGameResults(GameInfo info)
    {
        switch (ProfileHandler.Instance.ActiveProfile != null)
        {
            case true:
                Update_HighScores(info.Get_Score());
                AddToComponents(info.Get_lootedComponents());
                ProfileHandler.Instance.ProfileSave();
                break;
            case false:
                Debug.LogError("No active profile");
                break;
        }

    }
    public void AddToComponents(int[] lootedComponents)
    {
        for (int i = 0; i < lootedComponents.Length; i++)
        {
            ProfileHandler.Instance.ActiveProfile.ModifyNumberOf_Components(i, lootedComponents[i]);
        }
    }
    private void Update_HighScores(int newScore)
    {
        int[] highScores = new int[10];
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i] = ProfileHandler.Instance.ActiveProfile.Data.HighScores[i];
        }
        int temp = 0;
        for (int i = 0; i < highScores.Length; i++)
        {
            switch (newScore >= highScores[i])
            {
                case true:
                    temp = highScores[i];
                    highScores[i] = newScore;
                    newScore = temp;
                    break;
            }
        }
        ProfileHandler.Instance.ActiveProfile.Data.HighScores = highScores;
    }
}
