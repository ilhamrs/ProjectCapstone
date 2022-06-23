using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInPanel : MonoBehaviour
{
    Image TargetImage;
    public float FadeSpeed = 1;
    public float Delay = 3;
    bool StartFade = false;

    void Awake()
    {
        //Mendapatkan komponen Image secara otomatis. Catatan: Script ini harus dipasang di komponen Image
        TargetImage = GetComponent<Image>();
        TargetImage.enabled = false;

        //Membuat ukuran TargetImage sesuai dengan ukuran layar
        TargetImage.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void FadeIn()
    {
        //Membuat warna TargetImage pakai transisi Lerp dari warna awal ke warna transparan
        TargetImage.color = Color.Lerp(TargetImage.color, Color.clear, FadeSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void SetTrue_StartFade()
    {
        //Mengubah nilai StartFadeOut menjadi true
        StartFade = true;
        //Membuat TargetImage 'muncul' dari canvas
        TargetImage.enabled = true;
    }

    // Update is called once per frame
    public void EfekFade() 
    {
        Invoke("SetTrue_StartFade", Delay);
        if (StartFade)
        {
            FadeIn();
            TargetImage.color = Color.white;
            gameObject.SetActive(false);
        }
    }
}
