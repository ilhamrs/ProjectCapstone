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

    ChapterData dataChapOne;
    // Start is called before the first frame update
    void Start()
    {
        dataChapOne = ChapterOneSaveSystem.LoadGame();

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
            if(dataChapOne.time < 30 && dataChapOne.jmlRevisi < 5)
            {
                chapOneGrade.GetComponent<Image>().sprite = AGrade;
            } else if(dataChapOne.time < 45 && dataChapOne.jmlRevisi < 7)
            {
                chapOneGrade.GetComponent<Image>().sprite = BGrade;
            } else if (dataChapOne.time < 60 && dataChapOne.jmlRevisi < 10)
            {
                chapOneGrade.GetComponent<Image>().sprite = CGrade;
            }
            else
            {
                chapOneGrade.GetComponent<Image>().sprite = EGrade;
            }
        }
    }
}
