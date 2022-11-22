using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChapterSelectionManager : MonoBehaviour
{
    [Header("Grade Image")]
    [SerializeField] Sprite AGrade;
    [SerializeField] Sprite BGrade;
    [SerializeField] Sprite CGrade;
    [SerializeField] Sprite EGrade;

    [Header("Chapter One")]
    [SerializeField] TextMeshProUGUI chapOneTime;
    [SerializeField] TextMeshProUGUI chapOneRevision;
    [SerializeField] GameObject chapOneGrade;

    [Header("Chapter One Hard")]
    [SerializeField] TextMeshProUGUI chapOneHardTime;
    [SerializeField] TextMeshProUGUI chapOneHardRevision;
    [SerializeField] GameObject chapOneHardGrade;

    ChapterData dataChapOne;
    ChapterData dataChapOneHard;
    // Start is called before the first frame update
    void Start()
    {
        dataChapOne = ChapterOneSaveSystem.LoadGame("chapOne");
        dataChapOneHard = ChapterOneSaveSystem.LoadGame("chapOneHard");

        if (dataChapOne.Equals(null))
        {
            chapOneTime.text = "-";
            chapOneRevision.text = "-";
            chapOneGrade.SetActive(false);
        }
        else
        {
            //float minutes = Mathf.FloorToInt(dataChapOne.time / 60);
            //float seconds = Mathf.FloorToInt(dataChapOne.time % 60);

            //chapOneTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            //chapOneRevision.text = dataChapOne.jmlRevisi.ToString();
            CheckGrade(dataChapOne, chapOneTime, chapOneRevision, chapOneGrade);

        }

        if (dataChapOneHard.Equals(null))
        {
            chapOneHardTime.text = "-";
            chapOneHardRevision.text = "-";
            chapOneHardGrade.SetActive(false);
        }
        else
        {
            //float minutes = Mathf.FloorToInt(dataChapOneHard.time / 60);
            //float seconds = Mathf.FloorToInt(dataChapOneHard.time % 60);

            //chapOneHardTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            //chapOneHardRevision.text = dataChapOneHard.jmlRevisi.ToString();
            CheckGrade(dataChapOneHard, chapOneHardTime, chapOneHardRevision, chapOneHardGrade);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckGrade(ChapterData dataChap, TextMeshProUGUI chapTime, TextMeshProUGUI chapRevision, GameObject chapGrade)
    {
        float minutes = Mathf.FloorToInt(dataChap.time / 60);
        float seconds = Mathf.FloorToInt(dataChap.time % 60);

        chapTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        chapRevision.text = dataChap.jmlRevisi.ToString();

        if (dataChap.time <= 0 && dataChap.jmlRevisi <= 0)
        {
            chapGrade.SetActive(false);
        }
        else
        {
            chapGrade.SetActive(true);
            if(dataChap.jmlRevisi < 10)
            {
                chapGrade.GetComponent<Image>().sprite = AGrade;
            } else if(dataChap.jmlRevisi < 20)
            {
                chapGrade.GetComponent<Image>().sprite = BGrade;
            } else if (dataChap.jmlRevisi < 30)
            {
                chapGrade.GetComponent<Image>().sprite = CGrade;
            }
            else
            {
                chapGrade.GetComponent<Image>().sprite = EGrade;
            }
        }
    }

    //void CheckGradeHard()
    //{
    //    if (dataChapOneHard.time <= 0 && dataChapOneHard.jmlRevisi <= 0)
    //    {
    //        chapOneHardGrade.SetActive(false);
    //    }
    //    else
    //    {
    //        chapOneHardGrade.SetActive(true);
    //        if (dataChapOneHard.jmlRevisi < 10)
    //        {
    //            chapOneHardGrade.GetComponent<Image>().sprite = AGrade;
    //        }
    //        else if (dataChapOneHard.jmlRevisi < 20)
    //        {
    //            chapOneHardGrade.GetComponent<Image>().sprite = BGrade;
    //        }
    //        else if (dataChapOneHard.jmlRevisi < 30)
    //        {
    //            chapOneHardGrade.GetComponent<Image>().sprite = CGrade;
    //        }
    //        else
    //        {
    //            chapOneHardGrade.GetComponent<Image>().sprite = EGrade;
    //        }
    //    }
    //}
}
