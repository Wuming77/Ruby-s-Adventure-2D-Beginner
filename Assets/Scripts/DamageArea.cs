using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    /// <summary>
    /// ���������˺�����
    /// </summary>
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController ruby = other.GetComponent<RubyController>();
        if (ruby != null)
        {
            ruby.ChangeHealth(-1);
        }
    }

}
