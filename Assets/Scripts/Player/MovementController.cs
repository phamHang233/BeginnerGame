using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D body;
    [SerializeField] int speed;
    [SerializeField] float jumpCoolDown;
    // float multiplierSpeed;
    private Animator anim;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private AudioClip jumpSound;

    private float jumpTimer;
    private float horizontalInput;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        // Flipp player when moving left/right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }



        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());
        if (jumpTimer > jumpCoolDown)
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
                Jump();
            // if (OnWall() && !IsGrounded())
            // {
            //     body.gravityScale = 0;

            // }
            // else
            // body.gravityScale = 1;
        }
        jumpTimer += Time.deltaTime;


    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("grounded");
        SoundManager.instance.PlaySound(jumpSound);
        jumpTimer = 0;
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, Vector2.down, 0.1f);
        return raycastHit.collider != null;
    }

    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool CanAttack()
    {
        return horizontalInput == 0 && IsGrounded() && !OnWall();
    }
}
