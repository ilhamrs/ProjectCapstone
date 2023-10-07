using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class RevisiPanel : MonoBehaviour
{
    [SerializeField] GameObject revisiPanel;
    [SerializeField] Revisi revisi;
    [SerializeField] TextMeshProUGUI revisiText;

    public UnityEvent TriggerEvent;

    //[SerializeField] GameObject dudung;
    // Start is called before the first frame update
    void Start()
    {
        revisiPanel.SetActive(false);
    }

    public IEnumerator showPanel()
    {
        yield return new WaitForSeconds(0.8f);
        TriggerEvent.Invoke();
        revisiPanel.SetActive(true);
        revisiText.text = revisi.getRevisi().ToString();
        StartCoroutine(hidePanel());
    }

    public IEnumerator hidePanel()
    {
        yield return new WaitForSeconds(1f);
        revisiPanel.SetActive(false);
    }
}
