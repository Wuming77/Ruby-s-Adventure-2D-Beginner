using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public AudioClip hitClip;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Vector2 moveDirection, float moveForce)
    {
        rigidbody2d.AddForce(moveDirection * moveForce);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController ec = collision.gameObject.GetComponent<EnemyController>();
        if (ec != null)
        {
            ec.Fixed();
        }
        AudioManager.Instance.AudioPlay(hitClip);
        Destroy(gameObject);
    }
}
