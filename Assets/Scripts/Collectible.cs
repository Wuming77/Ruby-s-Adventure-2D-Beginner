using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public ParticleSystem PickupCollectibleEffect;

    public AudioClip collectClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //OnTriggerEnter : for Player
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController ruby = other.GetComponent<RubyController>();
        if (ruby != null)
        {
            if (ruby.CurrentHealth < ruby.MaxHealth)
            {
                ruby.ChangeHealth(1);

                Instantiate(PickupCollectibleEffect, transform.position,
                    Quaternion.identity);
                AudioManager.Instance.AudioPlay(collectClip);
                Destroy(this.gameObject);
            }
        }
    }
}
