using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    [SerializeField]
    GameObject attackHitBox;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckL;

    [SerializeField]
    Transform groundCheckR;

    [SerializeField]
    private float runSpeed = 1.5f;

    [SerializeField]
    private float jumpSpeed = 5f;

    bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        attackHitBox.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;

            //choose a random attack animation to play
            int index = UnityEngine.Random.Range(1, 4);
            animator.Play("Player_attack" + index);

            StartCoroutine(DoAttack());
        }
    }

    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(.12f);
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(.4f);
        attackHitBox.SetActive(false);
        isAttacking = false;
    }

    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            if (rb2d.velocity.y < 0 && !isAttacking)
            {
               animator.Play("Player_fall");
            }
        }

        if ((Input.GetKey("d") || Input.GetKey("right")) && !isAttacking)
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);

            if (isGrounded )
                animator.Play("Player_run");

            transform.localScale = new Vector3(1, 1, 1);
        }
        else if ((Input.GetKey("a") || Input.GetKey("left")) && !isAttacking)
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);

            if (isGrounded)
                animator.Play("Player_run");

            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

            if (isGrounded && !isAttacking)
                animator.Play("Player_idle");
        }

        if (Input.GetKey("space") && isGrounded && !isAttacking)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            // reset jump animation to the first frame
            animator.Play("Player_jump", -1, 0f);
        }
    }
}
