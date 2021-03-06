using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float blindSpot;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    Animator animator;

    bool gotHit;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer:" + distToPlayer);

        if (gotHit) {
            animator.Play("Goblin_takeHit");
        } else {
            if (distToPlayer < agroRange && distToPlayer > blindSpot)
            {
                ChasePlayer();
            }
            else
            {
                StopChasingPlayer();
            }
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;

        if (!gotHit)
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
        print(collision.gameObject.name);
        if (collision.gameObject.name == "AttackHitBox")
        {
            gotHit = true;
            
            Invoke("RecoverHit", .5f);
        }
    }

    void RecoverHit()
    {
        gotHit = false;
    }
}
