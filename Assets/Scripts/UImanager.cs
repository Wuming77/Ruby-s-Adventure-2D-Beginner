using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public static UImanager Instance { get; private set; }
    public Image healthBar;

    void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    public void UpdateHealthBar(int curAmount, int maxAmout)
    {
        healthBar.fillAmount = (float)curAmount / maxAmout;
    }
}
