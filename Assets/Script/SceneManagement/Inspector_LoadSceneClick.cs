/*
 * Desc     : Membuat fungsi perpindahan antar scene menggunakan event/click
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inspector_LoadSceneClick : MonoBehaviour
{

    [Header("Main Settings")]
    public string TargetScene;

    public void LoadScene()
    {
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        SceneManager.LoadScene(TargetScene);
    }
    
    public void MoveToScene(string sceneName)
    {
        //melakukan perpindahan antar scene berdasarkan nama scene
        SceneManager.LoadScene(sceneName);
    }
}
