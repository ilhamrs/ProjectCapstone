using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioClip uiButton;

    private AudioSource audioSfx;

    // Start is called before the first frame update
    private void Awake() 
    {
        audioSfx = GetComponent<AudioSource>();
    }

    public void UIClickSfx()
    {
        audioSfx.PlayOneShot(uiButton);
    }

    void Start()
    {

    }
}
