using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revisi : MonoBehaviour
{
    [SerializeField] Text revisiText;
    int jmlRevisi;
    // Start is called before the first frame update
    void Start()
    {
        jmlRevisi = 0;
        revisiText.text = jmlRevisi.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getHit()
    {
        jmlRevisi++;
        Debug.Log("get hit");
        revisiText.text = jmlRevisi.ToString();
    }

    public int getRevisi()
    {
        return jmlRevisi;
    }
}
