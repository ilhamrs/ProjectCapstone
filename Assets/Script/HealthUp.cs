using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] private float healthValue;
    public AudioSource pickupHealth;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
            pickupHealth.Play();
        }
    }
}
