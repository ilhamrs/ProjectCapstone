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
}
