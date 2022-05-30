using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject finishMenu;
    // Start is called before the first frame update
    void Start()
    {
        finishMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Time.timeScale = 0;
            finishMenu.SetActive(true);
        }
    }
}
