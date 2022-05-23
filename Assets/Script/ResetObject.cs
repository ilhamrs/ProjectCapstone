using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetObject : MonoBehaviour
{
    
    public GameObject objects;

    [Header("Conditional Event")]
    public UnityEvent ConditionalEvents;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Restart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Respawn()
    {
        Debug.Log("environment berhasil respawn");
        //ini dah bener, 0.1f biar jeda spawn objects ga keliatan
        Destroy(this.objects, 0f);
        //play animasi code disini
        Instantiate(objects, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
    public IEnumerator Restart() 
    {
        yield return new WaitForSeconds(0f);
        ConditionalEvents.Invoke();
    }
}
