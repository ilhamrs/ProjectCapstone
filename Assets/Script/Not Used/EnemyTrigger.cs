using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject objActive1;
    public GameObject objActive2;
    public GameObject objActive3;
    public GameObject objActive4;
    public GameObject objActive5;
    public GameObject objActive6;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player") 
        {
            objActive1.SetActive(true);
            objActive2.SetActive(true);
            objActive3.SetActive(true);
            objActive4.SetActive(true);
            objActive5.SetActive(true);
            objActive6.SetActive(true);
        }
    }
}
