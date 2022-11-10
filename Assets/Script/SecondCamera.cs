using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCamera : MonoBehaviour
{
    public GameObject player;
    //public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        //playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        if (isRight)
        {
            playerPosition = new Vector3(playerPosition.x - (Camera.main.aspect * -10), playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - (Camera.main.aspect * 10), playerPosition.y, playerPosition.z);
        }
        

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
    }
}
