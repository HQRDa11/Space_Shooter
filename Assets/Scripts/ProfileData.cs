using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProfileData
{
    public string AppVersion { get; set; }
    public string ProfileID { get; set; }
    public int GameCurrency { get; set; }
    public int[] HighScores { get; set; }
    public int[] Components { get; set; }

    public ProfileData()
    {
        AppVersion = ApplicationInfo.VERSION;
        ProfileID = "noID";
        GameCurrency = 0;
        HighScores = new int[10];
        Components = new int[6];
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
            highScores[i] = ProfileHandler.Instance.ActiveProfile.HighScores[i];
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
        ProfileHandler.Instance.ActiveProfile.HighScores = highScores;
    }
}
