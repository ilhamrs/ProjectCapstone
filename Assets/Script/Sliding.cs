using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour
{
    //private Rigidbody2D rb;

    private Animator anim;

    public bool active = true;
    private Collider2D col;

    [Header("SFX")]
    [SerializeField] private AudioSource deathSound;

    public Vector2 Checkpoint;

    [Header("Trigger Reset")]
    [SerializeField] Transform reset;

    void Start()
    {
        anim.GetComponent<Animator>();

        SetRespawnPoint(transform.position);
        col = GetComponent<Collider2D>();
    }

    public void Die()
    {
        active = false;
        anim.SetTrigger("goDie");
        col.enabled = false;
        //rb.gravityScale = 0;
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;
        deathSound.Play();
        StartCoroutine(Respawns());
    }

    public IEnumerator Respawns()
    {
        yield return new WaitForSeconds(1f);
       // rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        transform.position = Checkpoint;
        active = true;
        col.enabled = true;
        //rb.gravityScale = 6;
        yield return new WaitForSeconds(1f);
        reset.GetComponent<Reset>().ActivateRoom(false);
    }
    public void SetRespawnPoint(Vector2 position)
    {
        Checkpoint = position;
    }
}
