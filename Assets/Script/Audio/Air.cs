using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    [SerializeField] private AudioSource waterSound;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            waterSound.Play();
            
        }
    }

}
