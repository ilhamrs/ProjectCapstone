using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Z3_Language : MonoBehaviour
{

    [Header("Toggle")]
    public Toggle ArabicToggle;
    public Toggle IndonesiaToggle;
    public Toggle EnglishToggle;
    public Toggle KoreanToggle;
    public Toggle JapanToggle;
    public Toggle ChineseToggle;

    public void ResetLanguage()
    {
        PlayerPrefs.SetInt("Arabic", 0);
        PlayerPrefs.SetInt("Indonesia", 0);
        PlayerPrefs.SetInt("English", 0);
        PlayerPrefs.SetInt("Korean", 0);
        PlayerPrefs.SetInt("Japan", 0);
        PlayerPrefs.SetInt("Chinese", 0);
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

    public void SetArabic()
    {
        ResetLanguage();
        PlayerPrefs.SetInt("Arabic", 1);
    }

    public void SetKorean()
    {
        ResetLanguage();
        PlayerPrefs.SetInt("Korean", 1);
    }

    public void SetJapan()
    {
        ResetLanguage();
        PlayerPrefs.SetInt("Japan", 1);
    }

    public void SetChinese()
    {
        ResetLanguage();
        PlayerPrefs.SetInt("Chinese", 1);
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
        if (PlayerPrefs.HasKey("Arabic") && PlayerPrefs.GetInt("Arabic") == 1)
        {
            if (ArabicToggle) ArabicToggle.isOn = true;
        }
        if (PlayerPrefs.HasKey("Korean") && PlayerPrefs.GetInt("Korean") == 1)
        {
            if (KoreanToggle) KoreanToggle.isOn = true;
        }
        if (PlayerPrefs.HasKey("Japan") && PlayerPrefs.GetInt("Japan") == 1)
        {
            if (JapanToggle) JapanToggle.isOn = true;
        }
        if (PlayerPrefs.HasKey("Chinese") && PlayerPrefs.GetInt("Chinese") == 1)
        {
            if (ChineseToggle) ChineseToggle.isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
