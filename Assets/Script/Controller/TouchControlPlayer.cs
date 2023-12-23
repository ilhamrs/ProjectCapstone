using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControlPlayer : MonoBehaviour
{
    public GameObject player;
    public PlayerMove playerMove;
    public PlayerSlide playerSlide;
    public PlayerTeleport playerTeleport;
    private void Awake()
    {
        if (player == null)
        {
            GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in g)
            {
                if (p.activeInHierarchy && p.GetComponent<PlayerMove>() != null)
                {
                    player = p;
                    playerMove = player.GetComponent<PlayerMove>();
                    playerSlide = player.GetComponent<PlayerSlide>();
                    playerTeleport = player.GetComponent<PlayerTeleport>();
                }
            }
        }

        playerMove = player.GetComponent<PlayerMove>();
        playerSlide = player.GetComponent<PlayerSlide>();
        playerTeleport = player.GetComponent<PlayerTeleport>();
    }
    private void Update()
    {
        if (player == null)
        {
            GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
            foreach(GameObject p in g)
            {
                if (p.activeInHierarchy && p.GetComponent<PlayerMove>() != null)
                {
                    player = p;
                    playerMove = player.GetComponent<PlayerMove>();
                    playerSlide = player.GetComponent<PlayerSlide>();
                    playerTeleport = player.GetComponent<PlayerTeleport>();
                }
            }
        }

        if (!player.activeInHierarchy)
        {
            GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject p in g)
            {
                if (p.activeInHierarchy && p.GetComponent<PlayerMove>() != null)
                {
                    player = p;
                    playerMove = player.GetComponent<PlayerMove>();
                    playerSlide = player.GetComponent<PlayerSlide>();
                    playerTeleport = player.GetComponent<PlayerTeleport>();
                }
            }
        }
    }
    public void GoHorizontal(int i)
    {
        playerMove.MoveHorizontal(i);
    }
    public void Jump()
    {
        playerMove.Jump();
    }
    public void Slide()
    {
        playerSlide.Slide();
    }
    public void Action()
    {
        playerTeleport.InvokeTrigger();
    }
    public void MoveHorizontal(int i)
    {
        playerMove.MoveHorizontal(i);
    }
}
