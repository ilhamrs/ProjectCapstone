using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChapterSelectionManager : MonoBehaviour
{
    [Header("Chapter One")]
    [SerializeField] TextMeshProUGUI chapOneTime;
    [SerializeField] TextMeshProUGUI chapOneRevision;
    [SerializeField] GameObject chapOneGrade;
    // Start is called before the first frame update
    void Start()
    {
        ChapterData dataChapOne = ChapterOneSaveSystem.LoadGame();

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
            chapOneGrade.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
