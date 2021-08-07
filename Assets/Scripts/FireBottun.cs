using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireBottun : MonoBehaviour,IPointerDownHandler
{
    private RubyController ruby;
    void Awake()
    {
        ruby = GameObject.Find("Player").GetComponent<RubyController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ruby.Fire();
    }


    // Start is called before the first frame update
}
