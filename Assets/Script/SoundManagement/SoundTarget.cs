using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTarget : MonoBehaviour
{

    public string Key;
    AudioSource TargetAudio;

    void ChangeSound()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            TargetAudio.volume = PlayerPrefs.GetFloat(Key);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        TargetAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        ChangeSound();
    }
}
