using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChapterData
{
    public float time;
    public int jmlRevisi;

    public ChapterData(Timer timer, Revisi revisi)
    {
        time = timer.getTimer();
        jmlRevisi = revisi.getRevisi();
    }

    //jika tidak ada savegame
    public ChapterData()
    {
        time = 0;
        jmlRevisi = 0;
    }
}
