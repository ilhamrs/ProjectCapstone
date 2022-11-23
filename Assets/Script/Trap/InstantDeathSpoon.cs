using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstantDeathSpoon : MonoBehaviour
{
    [SerializeField] Revisi revision;

    public GameObject trapObject;
    public GameObject triggerTrap;
    Vector2 originalPos;

    [Header("Trigger Reset")]
    [SerializeField] Transform reset;

    private void Awake()
    {
        originalPos = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = originalPos;
    }
    protected void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerMove>();
        if (player != null)
        {
            reset.GetComponent<Reset>().ActivateRoom(true);
            player.Die();
            revision.getHit();
            StartCoroutine(Reset(1));
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            reset.GetComponent<Reset>().ActivateRoom(true);
            collision.GetComponent<PlayerMove>().Die();
            revision.getHit();
             StartCoroutine(Reset(1));
        }
    }
     IEnumerator Reset(float time)
    {
        yield return new WaitForSeconds(time);

        ResetObject reset = gameObject.GetComponent<ResetObject>();
        reset.nonactive();
        Debug.Log("reset");
    }
}
