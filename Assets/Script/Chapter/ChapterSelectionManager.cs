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
            float minutes = Mathf.FloorToInt(dataChapOne.time / 60);
            float seconds = Mathf.FloorToInt(dataChapOne.time % 60);

            chapOneTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            chapOneRevision.text = dataChapOne.jmlRevisi.ToString();
            CheckGrade();

        }

        if (dataChapOneHard.Equals(null))
        {
            chapOneHardTime.text = "-";
            chapOneHardRevision.text = "-";
            chapOneHardGrade.SetActive(false);
        }
        else
        {
            float minutes = Mathf.FloorToInt(dataChapOneHard.time / 60);
            float seconds = Mathf.FloorToInt(dataChapOneHard.time % 60);

            chapOneHardTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            chapOneHardRevision.text = dataChapOneHard.jmlRevisi.ToString();
            CheckGradeHard();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckGrade()
    {
        if (dataChapOne.time <= 0 && dataChapOne.jmlRevisi <= 0)
        {
            chapOneGrade.SetActive(false);
        }
        else
        {
            chapOneGrade.SetActive(true);
            if(dataChapOne.jmlRevisi < 10)
            {
                chapOneGrade.GetComponent<Image>().sprite = AGrade;
            } else if(dataChapOne.jmlRevisi < 20)
            {
                chapOneGrade.GetComponent<Image>().sprite = BGrade;
            } else if (dataChapOne.jmlRevisi < 30)
            {
                chapOneGrade.GetComponent<Image>().sprite = CGrade;
            }
            else
            {
                chapOneGrade.GetComponent<Image>().sprite = EGrade;
            }
        }
    }

    void CheckGradeHard()
    {
        if (dataChapOneHard.time <= 0 && dataChapOneHard.jmlRevisi <= 0)
        {
            chapOneHardGrade.SetActive(false);
        }
        else
        {
            chapOneHardGrade.SetActive(true);
            if (dataChapOneHard.jmlRevisi < 10)
            {
                chapOneHardGrade.GetComponent<Image>().sprite = AGrade;
            }
            else if (dataChapOneHard.jmlRevisi < 20)
            {
                chapOneHardGrade.GetComponent<Image>().sprite = BGrade;
            }
            else if (dataChapOneHard.jmlRevisi < 30)
            {
                chapOneHardGrade.GetComponent<Image>().sprite = CGrade;
            }
            else
            {
                chapOneHardGrade.GetComponent<Image>().sprite = EGrade;
            }
        }
    }
}
