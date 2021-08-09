using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireBottun : MonoBehaviour,IPointerDownHandler
{
    private RubyController ruby;
    void Start()
    {
        ruby = GameObject.Find("Player(Clone)").GetComponent<RubyController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ruby.Fire();
    }


    // Start is called before the first frame update
}
