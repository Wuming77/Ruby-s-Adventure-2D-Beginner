using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RubyController : MonoBehaviour
{
    public float speed;

    Rigidbody2D rigidbody2d;

    private int maxHealth = 5;

    [SerializeField]private int currentHealth;

    private float invincibleTime = 2f;

    private float invincibleTimer;

    private bool isInvincible;

    [SerializeField]Vector2 lookDirection = new Vector2(1, 0);
    Animator anim;

    public GameObject bulletPrefab;

    public Joystick joystick;

    public AudioClip hurtClip;
    public AudioClip launchClip;

    Vector2 fixedVector;


    // Start is called before the first frame update
    void Start()
    {
        invincibleTimer = 0;
        currentHealth = 4;
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UImanager.Instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RubyMove();
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }
    public int CurrentHealth
    {
        get { return currentHealth; }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }            
            isInvincible = true;
            invincibleTimer = invincibleTime;
            AudioManager.Instance.AudioPlay(hurtClip);
            anim.SetTrigger("Hit");
        }
        //把玩家的生命值约束在 0 和 最大值 之间
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UImanager.Instance.UpdateHealthBar(currentHealth, maxHealth);
    }
    void RubyMove()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        //设置动画
        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x != 0 || moveVector.y != 0)
        {
            lookDirection = moveVector;
            fixedVector = SetX_SetY(moveVector);
        }
        anim.SetFloat("Look X", fixedVector.x);
        anim.SetFloat("Look Y", fixedVector.y);
        anim.SetFloat("Speed", moveVector.magnitude);

        //Ruby移动
        Vector2 position = rigidbody2d.position;
        //position.x = position.x + 3.0f * moveX * Time.deltaTime;
        //position.y = position.y + 3.0f * moveY * Time.deltaTime;
        position += moveVector * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
    public void Fire()
    {
        anim.SetTrigger("Launch");
        AudioManager.Instance.AudioPlay(launchClip);
        GameObject bullet = Instantiate(bulletPrefab, rigidbody2d.position+new Vector2(0,0.5f),
            Quaternion.identity);
        BulletController bc = bullet.GetComponent<BulletController>();
        if (bc != null)
        {
            bc.Move(FireDirection(lookDirection), 300);
        }
    }
    Vector2 FireDirection(Vector2 lookDir)
    {
        float x = Mathf.Abs(lookDir.x);
        float y = Mathf.Abs(lookDir.y);
        if (x > y)
        {
            return lookDir.x > 0 ? new Vector2(1, 0) : new Vector2(-1, 0);
        }
        else
        {
            return lookDir.y > 0 ? new Vector2(0, 1) : new Vector2(0, -1);
        }
    }
    public void TalkWithNPC()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 2f, 
            LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            NpcMmanager npc = hit.collider.GetComponent<NpcMmanager>();
            if (npc != null)
            {
                npc.ShowDialog();
            }
        }
    }
    Vector2 SetX_SetY(Vector2 lookDirection)
    {
        float x;
        float y;
        if (lookDirection.x < 0)
        {
            x = lookDirection.x - 0.99f;
            if (lookDirection.y < 0)
            {
                y = lookDirection.y - 0.99f;
            }
            else
            {
                y = lookDirection.y + 0.99f;
            }
        }
        else
        {
            x = lookDirection.x;
            y = lookDirection.y;
        }
        Vector2 fixedVector = new Vector2(x, y);
        return fixedVector;
    }
}
