using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float distanceAheadHoriz;
    [SerializeField] private float distanceAheadVerti;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    private float lookAbove;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + lookAbove, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (distanceAheadHoriz * player.localScale.x), Time.deltaTime * cameraSpeed);
        lookAbove = Mathf.Lerp(lookAbove, (distanceAheadVerti * player.localScale.y), Time.deltaTime);
    }
}
