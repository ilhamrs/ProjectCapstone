using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject finishMenu;

    [SerializeField] Timer timer;
    [SerializeField] Revisi revisi;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI revisiText;
    [SerializeField] GameObject gradeImage;
    [SerializeField] GameObject highScoreText;
    [SerializeField] NumberCounter numberCounter;
    ChapterData dataChapOne;

    [Header("Grade Image")]
    [SerializeField] Sprite AGrade;
    [SerializeField] Sprite BGrade;
    [SerializeField] Sprite CGrade;
    [SerializeField] Sprite EGrade;
    // Start is called before the first frame update
    void Start()
    {
        finishMenu.SetActive(false);
        highScoreText.SetActive(false);
        gradeImage.SetActive(false);
        Time.timeScale = 1;
        dataChapOne = ChapterOneSaveSystem.LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ChapterOneSaveSystem.SaveGame(timer, revisi);

            Time.timeScale = 0;
            finishMenu.SetActive(true);

            float minutes = Mathf.FloorToInt(timer.getTimer() / 60);
            float seconds = Mathf.FloorToInt(timer.getTimer() % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            //revisiText.text = revisi.getRevisi().ToString();
            numberCounter.Value = revisi.getRevisi();

            StartCoroutine(CheckHighScore());
            StartCoroutine(CheckGrade());
        }
    }

    IEnumerator CheckGrade()
    {
        yield return new WaitForSecondsRealtime(1);

        if (revisi.getRevisi() < 10)
        {
            gradeImage.GetComponent<Image>().sprite = AGrade;
        }
        else if (revisi.getRevisi() < 20)
        {
            gradeImage.GetComponent<Image>().sprite = BGrade;
        }
        else if (revisi.getRevisi() < 30)
        {
            gradeImage.GetComponent<Image>().sprite = CGrade;
        }
        else
        {
            gradeImage.GetComponent<Image>().sprite = EGrade;
        }

        gradeImage.SetActive(true);
    }

    IEnumerator CheckHighScore()
    {
        yield return new WaitForSecondsRealtime(2);

        if (revisi.getRevisi() <= dataChapOne.jmlRevisi && timer.getTimer() <= dataChapOne.time)
        {
            highScoreText.SetActive(true);
        }
        else
        {
            highScoreText.SetActive(false);
        }
    }
}
