using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject finishMenu;

    [SerializeField] Timer timer;
    [SerializeField] Revisi revisi;

    [SerializeField] Text timerText;
    [SerializeField] Text revisiText;
    // Start is called before the first frame update
    void Start()
    {
        finishMenu.SetActive(false);
        Time.timeScale = 1;
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

            timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            revisiText.text = "Revision: " + revisi.getRevisi().ToString();
        }
    }
}
