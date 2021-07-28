using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float Move_speed = 3;
    bool isTouchTop;
    bool isTouchBottom;
    bool isTouchRight;
    bool isTouchLeft;

    private bool attacking = false;
    private float attackDelay = 1.8f;

    private PlayerStatus thePlayerStat;
    private Animator animator;
    public Slider HpSlider;
    private void Start()
    {
        thePlayerStat = GetComponent<PlayerStatus>();
        HpSlider.maxValue = thePlayerStat.hp;
        animator = GetComponent<Animator>();
        attackDelay -= thePlayerStat.Dex / 7;
        Move_speed += thePlayerStat.Dex / 10;        
    }
    


    void Update()
    {
        
        HpSlider.value = thePlayerStat.currentHP;
        Attack();
        Move();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        if ((isTouchLeft && h == -1) || (isTouchRight && h == 1))
            h = 0;
        float v = Input.GetAxisRaw("Vertical");
        
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;
        
        Vector2 curPos = transform.position;
        Vector2 nextPos = new Vector2(h,v) * Move_speed * Time.deltaTime;

        transform.position = curPos + nextPos;
        
        if(Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetFloat("DirX", h);
            animator.SetFloat("DirY", v);
            animator.SetBool("Walking", true);
        }
        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            animator.SetBool("Walking", false);
        }
    }
    IEnumerator CountAttackDelay()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(attackDelay);
        attacking = false;
        
    }
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!attacking)
            {
                attacking = true;
                animator.SetBool("Attacking", true);
                
                StartCoroutine(CountAttackDelay());
            }
            
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
            }
        }
        else if(collision.gameObject.tag == "enemy")
        {
            if (thePlayerStat.HitDelay)
                return;
            thePlayerStat.Hit(30);

            Vector2 curpos = transform.position;
            curpos.y -= 0.5f;
            transform.position = curpos;
        }
        else if(collision.gameObject.tag == "Boss")
        {
            Vector2 curpos = transform.position;
            curpos.y -= 0.1f;
            transform.position = curpos;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
            }
        }
    }
}
