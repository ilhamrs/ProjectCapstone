using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundLampu : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    [SerializeField] private AudioSource LampSound;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LampSound.Play();
            //mungkin disini pengen ditambahin trigger event buat setactive checkpoint trap
        }
        if (collision.tag == "Ground") 
        {
            LampSound.Play();
        }
    }
}
