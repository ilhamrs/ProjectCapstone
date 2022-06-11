using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagement : MonoBehaviour
{
    private static MusicManagement instance = null;
    public static MusicManagement Instance 
    {
        get { return instance; }
    }

        void Awake()
        {
            if (instance != null && instance != this) 
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                instance = this;
                
            }
        GameObject.DontDestroyOnLoad(gameObject);
    }
    }
