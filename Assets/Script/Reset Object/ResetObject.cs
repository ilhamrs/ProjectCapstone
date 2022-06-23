using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetObject : MonoBehaviour
{
    public GameObject trapObject;
    public GameObject triggerTrap;

    public void active() 
    {
        trapObject.SetActive(true);
        triggerTrap.SetActive(false);
    }

    public void nonactive() 
    {
        trapObject.SetActive(false);
        triggerTrap.SetActive(true);
    }
}
