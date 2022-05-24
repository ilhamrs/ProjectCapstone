using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    public bool isSliding = false;

    public PlayerMove playerMove;

    public Rigidbody2D rb;

    public Animator anim;

    public BoxCollider2D regularColl;
    public BoxCollider2D slideColl;

    public float slideSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            perfomSlide();
        }
    }

    private void perfomSlide() 
    {
        isSliding = true;

        //ini animasi slide

        regularColl.enabled = false;
        slideColl.enabled = true;

        if (!playerMove.sprite)
        {
            rb.AddForce(Vector2.right * slideSpeed);
        }
        else
        {
            rb.AddForce(Vector2.left * slideSpeed);
        }

        StartCoroutine("stopslide");
    }

    IEnumerator stopslide() 
    {
        yield return new WaitForSeconds(0.8f);
        //ini animasi
        regularColl.enabled = true;
        slideColl.enabled = false;
        isSliding = false;
    }
}
