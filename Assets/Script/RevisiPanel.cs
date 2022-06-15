using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RevisiPanel : MonoBehaviour
{
    [SerializeField] GameObject revisiPanel;
    [SerializeField] Revisi revisi;
    [SerializeField] TextMeshProUGUI revisiText;

    //[SerializeField] GameObject dudung;
    // Start is called before the first frame update
    void Start()
    {
        revisiPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPanel()
    {
        revisiPanel.SetActive(true);
        revisiText.text = revisi.getRevisi().ToString();
        StartCoroutine(hidePanel());
    }

    public IEnumerator hidePanel()
    {
        yield return new WaitForSeconds(2f);
        revisiPanel.SetActive(false);
    }
}
