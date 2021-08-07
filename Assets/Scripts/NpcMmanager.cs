using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcMmanager : MonoBehaviour
{
    public GameObject tipgImage;

    public GameObject dialogImage;
    public float showTime = 4;
    private float showTimer;
    // Start is called before the first frame update
    void Start()
    {
        tipgImage.SetActive(true);
        dialogImage.SetActive(false);
        showTimer = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        showTimer -= Time.deltaTime;

        if (showTimer < 0)
        {
            tipgImage.SetActive(true);
            dialogImage.SetActive(false);
        }
    }
    public void ShowDialog()
    {
        showTimer = showTime;
        tipgImage.SetActive(false);
        dialogImage.SetActive(true);
    }
}
