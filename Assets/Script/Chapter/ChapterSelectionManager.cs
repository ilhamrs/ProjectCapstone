using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

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

    [Header("Chapter Two")]
    [SerializeField] TextMeshProUGUI chapTwoTime;
    [SerializeField] TextMeshProUGUI chapTwoRevision;
    [SerializeField] GameObject chapTwoGrade;

    [Header("Chapter Three")]
    [SerializeField] TextMeshProUGUI chapThreeTime;
    [SerializeField] TextMeshProUGUI chapThreeRevision;
    [SerializeField] GameObject chapThreeGrade;

    ChapterData dataChapOne;
    ChapterData dataChapTwo;
    ChapterData dataChapThree;
 
    // Start is called before the first frame update
    void Start()
    {
        dataChapOne = ChapterOneSaveSystem.LoadGame("chapOne");
        dataChapTwo = ChapterOneSaveSystem.LoadGame("chapTwo");
        //dataChapThree = ChapterOneSaveSystem.LoadGame("chapThree");

        CheckGrade(dataChapOne, chapOneTime, chapOneRevision, chapOneGrade);

        CheckPrevChap(dataChapOne, dataChapTwo, chapTwoTime, chapTwoRevision, chapTwoGrade);
        //CheckGrade(dataChapThree, chapThreeTime, chapThreeRevision, chapThreeGrade);



    }

    void CheckGrade(ChapterData dataChap, TextMeshProUGUI chapTime, TextMeshProUGUI chapRevision, GameObject chapGrade)
    {
        if(dataChap.Equals(null))
        {
            chapTime.text = "-";
            chapRevision.text = "-";
            chapGrade.SetActive(false);
        }
        else
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
                if (dataChap.jmlRevisi < 10)
                {
                    chapGrade.GetComponent<Image>().sprite = AGrade;
                }
                else if (dataChap.jmlRevisi < 20)
                {
                    chapGrade.GetComponent<Image>().sprite = BGrade;
                }
                else if (dataChap.jmlRevisi < 30)
                {
                    chapGrade.GetComponent<Image>().sprite = CGrade;
                }
                else
                {
                    chapGrade.GetComponent<Image>().sprite = EGrade;
                }
            }
        }
        
    }

    void CheckPrevChap(ChapterData prevDataChap, ChapterData dataChap, TextMeshProUGUI chapTime, TextMeshProUGUI chapRevision, GameObject chapGrade)
    {
        if (!prevDataChap.Equals(null))
        {
            Debug.Log("ada save!");
            CheckGrade(dataChap, chapTime, chapRevision, chapGrade);
        }
        else
        {
            Debug.Log("tidak ada save!");
        }
    }

}
