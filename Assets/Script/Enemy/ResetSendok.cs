using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSendok : MonoBehaviour
{
    public Reset resetObject;
    public GameObject sendok;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        isActive = sendok.activeInHierarchy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isActive)
        {
            sendok.SetActive(false);
            Invoke("ResetPosition", 2);
        }
    }

    private void ResetPosition()
    {
        sendok.SetActive(true);
        isActive = false;
    }
}
