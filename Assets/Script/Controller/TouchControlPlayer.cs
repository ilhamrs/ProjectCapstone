using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControlPlayer : MonoBehaviour
{
    public PlayerMove playerMove;
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

    }
}
