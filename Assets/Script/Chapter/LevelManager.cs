using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public List<string> levelScene;
    
    public Difficulty difficultySelected;
    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadEasyLevel(int i)
    {
        string lvl = levelScene[i];
        difficultySelected = Difficulty.Easy;

        MoveToScene(lvl);
    }
    public void LoadHardLevel(int i)
    {
        string lvl = levelScene[i];
        difficultySelected = Difficulty.Hard;

        MoveToScene(lvl);
    }
    public void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
public enum Difficulty
{
    Easy,
    Hard
}
