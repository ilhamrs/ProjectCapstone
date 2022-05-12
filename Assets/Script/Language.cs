using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{

    [Header("Toggle")]
    public Toggle IndonesiaToggle;
    public Toggle EnglishToggle;

    public void ResetLanguage()
    {
        PlayerPrefs.SetInt("Indonesia", 0);
        PlayerPrefs.SetInt("English", 0);
    }

    public void SetIndonesia()
    {
        ResetLanguage();
        PlayerPrefs.SetInt("Indonesia", 1);
    }

    public void SetEnglish()
    {
        ResetLanguage();
        PlayerPrefs.SetInt("English", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Indonesia") && PlayerPrefs.GetInt("Indonesia") == 1)
        {
            if (IndonesiaToggle) IndonesiaToggle.isOn = true;
        }
        if (PlayerPrefs.HasKey("English") && PlayerPrefs.GetInt("English") == 1)
        {
            if (EnglishToggle) EnglishToggle.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
