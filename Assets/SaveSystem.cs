using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;

public static class SaveSystem 
{
    public static readonly string SAVE_FOLDER = Application.persistentDataPath + "/Saves/";
    public static void Init()
    {
        Try_SaveFolder();
    }

    public static void Save(string saveString)
    {
        // Find availible save ID;
        int saveNumber = 1;
        while(File.Exists(SAVE_FOLDER + "save_" + saveNumber + ".txt"))
        {
            saveNumber++;
        }
        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + ".txt", saveString);
        { 
        }
    }

    public static string LoadMostRecentFile()
    {
        // get most recent save;
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles();
        FileInfo mostReccentFile = null;

        foreach (FileInfo fileInfo in saveFiles)
        {
            if(mostReccentFile == null)
            {
                mostReccentFile = fileInfo;
            }
            else if (fileInfo.LastWriteTime>mostReccentFile.LastWriteTime)
            {
                mostReccentFile = fileInfo;
            }
        }
        if (mostReccentFile != null)
        {
            Debug.Log(mostReccentFile.FullName);
            string saveString = File.ReadAllText( mostReccentFile.FullName);
            return saveString;
        }
        else { return null; }
    }

    public static void Try_SaveFolder()
    {
        // If their is no directory:
        if (!Directory.Exists(SAVE_FOLDER))
        {
            //Create it:
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
}
