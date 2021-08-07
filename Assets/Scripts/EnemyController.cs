using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5;

    public bool isVertical; //是否为垂直方向移动
    public float changeDirectionTime = 3f;
    private float changeTimer;
    private Vector2 moveDirection; //移动方向
    private Animator anim;

    private Rigidbody2D rigidbody2d;
    private bool isFixed;
    public ParticleSystem brokenEffect;
    public AudioClip fixedClip;
    // Start is called before the first frame update
    void Start()
    {
        changeTimer = changeDirectionTime;
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //如果是垂直移动，方向就是上下；否则方向就是水平
        moveDirection = isVertical ? Vector2.up : Vector2.right;
        
    }
    void Update()
    {
        ChangeTimer();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMove();
    }
    void EnemyMove()
    {
        if (isFixed) return;

        Vector2 position = rigidbody2d.position;
        position.x += moveDirection.x * speed * Time.deltaTime * 1.3f;
        position.y += moveDirection.y * speed * Time.deltaTime * 1.3f;
        rigidbody2d.MovePosition(position);
        anim.SetFloat("moveX", moveDirection.x);
        anim.SetFloat("moveY", moveDirection.y);
    }
    void ChangeTimer()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController ruby = collision.gameObject.GetComponent<RubyController>();
        if (ruby != null)
        {
            ruby.ChangeHealth(-1);
        }
    }
    public void Fixed()
    {
        isFixed = true;
        if (brokenEffect.isPlaying)
        {
            brokenEffect.Stop();
        }
        AudioManager.Instance.AudioPlay(fixedClip);        
        rigidbody2d.simulated = false;
        anim.SetTrigger("fix");
        Destroy(gameObject, 1.5f);
    } 
}
