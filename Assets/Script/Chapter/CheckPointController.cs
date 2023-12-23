using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public Difficulty diffSelected = Difficulty.Easy;
    public List<Transform> easyCheckPoint;
    // Start is called before the first frame update
    void Start()
    {
        if(LevelManager.Instance != null)
        {
            diffSelected = LevelManager.Instance.difficultySelected;
        }

        foreach (Transform t in easyCheckPoint)
        {
            t.gameObject.SetActive(diffSelected == Difficulty.Easy);
        }
    }
}
