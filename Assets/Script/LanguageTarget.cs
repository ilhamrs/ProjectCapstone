using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageTarget : MonoBehaviour
{

    Text TargetText;

    [Header("Language Settings")]
    [TextArea(5, 10)]
    public string IndonesianText;
    [TextArea(5, 10)]
    public string EnglishText;



    void ChangeLanguage()
    {
        if (PlayerPrefs.GetInt("Indonesia") == 1)
        {
            TargetText.text = IndonesianText;
        }
        if (PlayerPrefs.GetInt("English") == 1)
        {
            TargetText.text = EnglishText;
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
