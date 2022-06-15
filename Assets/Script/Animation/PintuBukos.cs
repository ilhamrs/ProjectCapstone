using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuBukos : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource suaraPintu;
    [SerializeField] private AudioSource suaraMarah;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("isOpen");
        suaraMarah.Play();
        suaraPintu.Play();

    }
    public void animasiBukaPintu()
    {
        anim.SetTrigger("isOpen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
