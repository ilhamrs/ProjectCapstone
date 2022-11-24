using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveButton : MonoBehaviour
{
    public Image oldimage;
    public Sprite newimage;
    void ChangeSprite()
    {
        oldimage.sprite = newimage;
    }
    void Awake()
    {
        ChangeSprite();
    }
}
