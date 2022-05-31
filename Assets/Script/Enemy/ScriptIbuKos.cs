using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptIbuKos : MonoBehaviour
{
    public float speed, stopDistance, retreatDistance;
    private float timeShots;
    public float startTimeShots;
    public GameObject projectile;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeShots = startTimeShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance )
        {
            transform.position = this.transform.position;
        }else if(Vector2.Distance(transform.position, player.position) < retreatDistance )
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeShots = startTimeShots;
        }
        else
        {
            timeShots -= Time.deltaTime;
        }
    }
}
