using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ChapterOneSaveSystem
{
    public static void SaveGame(Timer timer, Revisi revisi)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/chapOne.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        ChapterData data = new ChapterData(timer, revisi);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    //jika tidak ada savegame
    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/chapOne.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        ChapterData data = new ChapterData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ChapterData LoadGame()
    {
        string path = Application.persistentDataPath + "/chapOne.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ChapterData data = formatter.Deserialize(stream) as ChapterData;
            stream.Close();

            return data;
        }
        else
        {
            SaveGame();

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ChapterData data = formatter.Deserialize(stream) as ChapterData;
            stream.Close();

            return data;
        }
    }
}
