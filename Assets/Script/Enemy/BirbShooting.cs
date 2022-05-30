using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbShooting : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] taiBirb;

    public void attack() 
    {
        taiBirb[FindTai()].transform.position = firepoint.position;
        taiBirb[FindTai()].GetComponent<ExplodeEffect>().Fall();
        taiBirb[FindTai()].GetComponent<FallingObjects>().Fall();
    }

    private int FindTai() 
    {
        for (int i = 0; i < taiBirb.Length; i++)
        {
            if (!taiBirb[i].activeInHierarchy)
            {
                return i;
            }
        }return 0;
    }
}
