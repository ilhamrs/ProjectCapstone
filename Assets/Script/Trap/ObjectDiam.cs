using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDiam : MonoBehaviour
{
    [SerializeField] Revisi revisi;
    public BoxCollider2D boxCollider2D;
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
            revisi.getHit();
            //StartCoroutine(Reset(1));
            //mungkin disini pengen ditambahin trigger event buat setactive checkpoint trap
        }
    }
}
