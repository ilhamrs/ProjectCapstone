using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenuEsc : MonoBehaviour
{
    public GameObject optionsMenu;

    [Header("Main Settings")]
    public UnityEvent StartEvent;
    public bool DestroyTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartEvent.Invoke();
            // Check whether it's active / inactive 
            bool isActive = optionsMenu.activeSelf;

            optionsMenu.SetActive(!isActive);
        }
    }
    public void InvokeTrigger()
    {
        StartEvent.Invoke();
        bool isActive = optionsMenu.activeSelf;

        optionsMenu.SetActive(!isActive);
    }
    public void delay() 
    {
        gameObject.SetActive(true);
    }
    public void PauseButton()
    {
        StartEvent.Invoke();
        // Check whether it's active / inactive 
        bool isActive = optionsMenu.activeSelf;

        optionsMenu.SetActive(!isActive);
    }
}
