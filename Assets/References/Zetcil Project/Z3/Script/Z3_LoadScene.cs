using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Z3_LoadScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    public void InvokeLoadScene(string aValue)
    {
        SceneManager.LoadScene(aValue);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

