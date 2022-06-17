using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoLooping : MonoBehaviour
{
    VideoPlayer video;
    public string TargetScene;

    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;


    }


    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(TargetScene);//the scene that you want to load after the video has ended.
    }
}
