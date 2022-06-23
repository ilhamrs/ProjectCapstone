using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject SettingPanel;
    public GameObject CreditsPanel;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        SettingPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void SettingButton()
    {
        MainPanel.SetActive(false);
        SettingPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void CreditsButton()
    {
        MainPanel.SetActive(false);
        SettingPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void Back()
    {
        MainPanel.SetActive(true);
        SettingPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
