using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TalkWithNPC : MonoBehaviour, IPointerDownHandler
{

    private RubyController ruby;
    // Start is called before the first frame update
    void Awake()
    {
        ruby = GameObject.Find("Player").GetComponent<RubyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ruby.TalkWithNPC();
    }
}
