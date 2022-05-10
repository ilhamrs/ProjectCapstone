using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Z3_LanguageTarget : MonoBehaviour
{

    Text TargetText;

    [Header("Language Settings")]
    [TextArea(5, 10)]
    public string ArabicText;
    [TextArea(5, 10)]
    public string IndonesianText;
    [TextArea(5, 10)]
    public string EnglishText;
    [TextArea(5, 10)]
    public string KoreanText;
    [TextArea(5, 10)]
    public string JapanText;
    [TextArea(5, 10)]
    public string ChineseText;



    void ChangeLanguage()
    {
        if (PlayerPrefs.GetInt("Arabic") == 1)
        {
            TargetText.text = ArabicText;
        }
        if (PlayerPrefs.GetInt("Indonesia") == 1)
        {
            TargetText.text = IndonesianText;
        }
        if (PlayerPrefs.GetInt("English") == 1)
        {
            TargetText.text = EnglishText;
        }
        if (PlayerPrefs.GetInt("Korean") == 1)
        {
            TargetText.text = KoreanText;
        }
        if (PlayerPrefs.GetInt("Japan") == 1)
        {
            TargetText.text = JapanText;
        }
        if (PlayerPrefs.GetInt("Chinese") == 1)
        {
            TargetText.text = ChineseText;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TargetText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        ChangeLanguage();
    }
}
