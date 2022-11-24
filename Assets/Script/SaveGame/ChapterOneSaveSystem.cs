using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class ChapterOneSaveSystem
{
    public static void SaveGame(Timer timer, Revisi revisi, string chapName)
    {
        string chapterName = "/" + chapName + ".sav";
        string path = Application.persistentDataPath + chapterName;

        if (!File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            ChapterData data = new ChapterData(timer, revisi);

            formatter.Serialize(stream, data);
            stream.Close();
        }
        else
        {
            ChapterData data = LoadGame(chapName);

            if(timer.getTimer() <= data.time && revisi.getRevisi() <= data.jmlRevisi)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Create);

                ChapterData data2 = new ChapterData(timer, revisi);

                formatter.Serialize(stream, data2);
                stream.Close();
            }
        }
        
    }

    //jika tidak ada savegame
    public static void SaveGame(string chapName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string chapterName = "/" + chapName + ".sav";
        string path = Application.persistentDataPath + chapterName;
        FileStream stream = new FileStream(path, FileMode.Create);

        ChapterData data = new ChapterData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ChapterData LoadGame(string chapName)
    {
        string chapterName = "/" + chapName + ".sav";
        string path = Application.persistentDataPath + chapterName;
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
            //SaveGame();

            //BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream(path, FileMode.Open);

            //ChapterData data = formatter.Deserialize(stream) as ChapterData;
            //stream.Close();

            //return data;
            return null;
        }
    }
}
