using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ChapterSelectionHard : MonoBehaviour
{
    [Header("Grade Image")]
    [SerializeField] Sprite AGrade;
    [SerializeField] Sprite BGrade;
    [SerializeField] Sprite CGrade;
    [SerializeField] Sprite EGrade;

    [Header("Chapter One Hard")]
    [SerializeField] TextMeshProUGUI chapOneHardTime;
    [SerializeField] TextMeshProUGUI chapOneHardRevision;
    [SerializeField] GameObject chapOneHardGrade;

    [Header("Chapter Two Hard")]
    [SerializeField] GameObject chapTwoHardButton;
    [SerializeField] Sprite chapTwoHardUnlock;
    [SerializeField] TextMeshProUGUI chapTwoHardTime;
    [SerializeField] TextMeshProUGUI chapTwoHardRevision;
    [SerializeField] GameObject chapTwoHardGrade;

    [Header("Chapter Three Hard")]
    [SerializeField] GameObject chapThreeHardButton;
    [SerializeField] Sprite chapThreeHardUnlock;
    [SerializeField] TextMeshProUGUI chapThreeHardTime;
    [SerializeField] TextMeshProUGUI chapThreeHardRevision;
    [SerializeField] GameObject chapThreeHardGrade;

    
    ChapterData dataChapOneHard;
    ChapterData dataChapTwoHard;
    ChapterData dataChapThreeHard;

    // Start is called before the first frame update
    void Start()
    {
        dataChapOneHard = ChapterOneSaveSystem.LoadGame("chapOneHard");
        dataChapTwoHard = ChapterOneSaveSystem.LoadGame("chapTwoHard");
        dataChapThreeHard = ChapterOneSaveSystem.LoadGame("chapThreeHard");

        CheckGrade(dataChapOneHard, chapOneHardTime, chapOneHardRevision, chapOneHardGrade);

        CheckPrevChap(dataChapOneHard, dataChapTwoHard, chapTwoHardTime, chapTwoHardRevision, chapTwoHardGrade, chapTwoHardButton, chapTwoHardUnlock);
        CheckPrevChap(dataChapTwoHard, dataChapThreeHard, chapThreeHardTime, chapThreeHardRevision, chapThreeHardGrade, chapThreeHardButton, chapThreeHardUnlock);


    }

    void CheckGrade(ChapterData dataChap, TextMeshProUGUI chapTime, TextMeshProUGUI chapRevision, GameObject chapGrade)
    {
        if (dataChap.Equals(null))
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
                if (dataChap.jmlRevisi < 5)
                {
                    chapGrade.GetComponent<Image>().sprite = AGrade;
                }
                else if (dataChap.jmlRevisi < 10)
                {
                    chapGrade.GetComponent<Image>().sprite = BGrade;
                }
                else if (dataChap.jmlRevisi < 20)
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

    void CheckPrevChap(ChapterData prevDataChap, ChapterData dataChap, TextMeshProUGUI chapTime, TextMeshProUGUI chapRevision, GameObject chapGrade, GameObject chapButton, Sprite chapImageUnlock)
    {
        if (prevDataChap.Equals(null))
        {
            Debug.Log("tidak ada save!");
            chapButton.GetComponent<Button>().interactable = false;

        }
        else
        {
            Debug.Log("ada save!");
            chapButton.GetComponent<Button>().interactable = true;
            chapButton.GetComponent<Image>().sprite = chapImageUnlock;
            CheckGrade(dataChap, chapTime, chapRevision, chapGrade);
        }
    }

}
