using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{

    [Header("Toggle")]
    public Slider BGMSlider;
    public Slider SFXSlider;

    public void ResetSound()
    {
        PlayerPrefs.SetFloat("BGM", 0);
        PlayerPrefs.SetFloat("SFX", 0);
    }

    public void SetBGM(Slider slider)
    {
        PlayerPrefs.SetFloat("BGM", slider.value);
    }

    public void SetSFX(Slider slider)
    {
        PlayerPrefs.SetFloat("SFX", slider.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("BGM"))
        {
            if (BGMSlider) BGMSlider.value = PlayerPrefs.GetFloat("BGM");
        }
        if (PlayerPrefs.HasKey("SFX"))
        {
            if (SFXSlider) SFXSlider.value = PlayerPrefs.GetFloat("SFX");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
