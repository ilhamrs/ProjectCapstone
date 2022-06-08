using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MengTrigger : MonoBehaviour
{
    [Header("Main Settings")]
    public string TagObject;
    public UnityEvent TriggerEvent;
    public bool DestroyTrigger;
    public SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void InvokeTrigger()
    {
        TriggerEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == TagObject)
        {
            Debug.Log("Berhasil Trigger");
            TriggerEvent.Invoke();
            if (DestroyTrigger)
            {
                Destroy(other.gameObject);
            }
        }
    }
    public IEnumerator delaySprite() 
    {
        sprite.enabled = true;
        yield return new WaitForSeconds(0);
        TriggerEvent.Invoke();
    }
}
