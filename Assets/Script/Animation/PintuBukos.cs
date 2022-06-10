using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuBukos : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("isOpen");

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
