using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange = 4f;

    [SerializeField]
    float attackRange = 1.5f;

    [SerializeField]
    float moveSpeed = 1f;

    Rigidbody2D rb2d;

    Animator animator;

    bool gotHit;

    [SerializeField]
    Transform groundCheck;

    bool isGrounded;

    bool isDead;

    private int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isDead || gotHit) return;

        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded && distToPlayer < agroRange && distToPlayer > attackRange)
        {
            ChasePlayer();
        } else if (isGrounded && distToPlayer < attackRange) {
            Attack();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    void Attack()
    {
        rb2d.velocity = Vector2.zero;
        animator.Play("Goblin_attack1");
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
        animator.Play("Goblin_idle");
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(2.2f, 2.2f);

        }
        else
        {
            //enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-2.2f, 2.2f);
        }

        animator.Play("Goblin_run");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sword"))
        {
            gotHit = true;
            rb2d.velocity = Vector2.zero;
            animator.Play("Goblin_takeHit");
            Invoke("RecoverHit", .4f);

            health--;
            if (health <= 0){
                KillSelf();
            }
        }
    }

    void RecoverHit()
    {
        gotHit = false;
    }

    void KillSelf()
    {
        isDead = true;
        animator.Play("Goblin_die");
        Invoke("Dissolve", 10f);
    }

    void Dissolve()
    {
        Destroy(gameObject);
    }
}
