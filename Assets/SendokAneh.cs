using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendokAneh : MonoBehaviour
{
    public float count;
    public BoxCollider2D boxCollider2D;
    public Animator sendokAnim;
    // Start is called before the first frame update
    void Start()
    {
        count = 0f;
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addCount()
    {
        count = count + Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            addCount();
            if(count >= 5)
            {
                sendokAnim.SetBool("isOpen", true);
                StartCoroutine(Reset(10));
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            count = 0;
        }
    }

    IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        sendokAnim.SetBool("isOpen", false);
        Debug.Log("reset");
    }


}
