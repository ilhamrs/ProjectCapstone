using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip uiButton;

    private AudioSource audio;

    // Start is called before the first frame update
    private void Awake() 
    {
        audio = GetComponent<AudioSource>();
    }

    public void UIClickSfx()
    {
        audio.PlayOneShot(uiButton);
    }

    void Start()
    {

    }
}
