using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject SettingPanel;
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }

    public void SettingButton()
    {
        MainPanel.SetActive(false);
        SettingPanel.SetActive(true);
        SoundManager.instance.UIClickSfx();
    }

    public void Back()
    {
        MainPanel.SetActive(true);
        SettingPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
