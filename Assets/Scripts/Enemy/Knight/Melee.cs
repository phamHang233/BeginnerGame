using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Melee : EnemyDamage
{
    [Header("Movement")]
    [SerializeField] private float startHealth;
    [SerializeField] private float speed;

    [SerializeField] private float distance;
    private float leftEdge;
    private float rightEdge;
    private Animator anim;
    private bool movingLeft;

    [Header("fireBall")]
    [SerializeField] private GameObject[] fireBalls;
    [SerializeField] private Transform firePoint;



    private void Awake()
    {
        anim = GetComponent<Animator>();
        leftEdge = transform.position.x - distance;
        rightEdge = transform.position.x + distance;
    }

    void Update()
    {
        if (movingLeft)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        Move();
        // print(!GetComponent<FireBallAttack>().PlayerInsight());
        // this.enabled = !GetComponent<KnightAttack>().PlayerInsight() && !GetComponent<FireBallAttack>().PlayerInsight();
    }

    private void Move()
    {
        anim.SetBool("run", true);
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            else
                movingLeft = true;
        }
    }

    // private void FindPlayer()
    // {
    //     if (coolDownTimer > attackCoolDown)
    //     {
    //         CheckDirection();
    //         for (int i = 0; i < directions.Length; i++)
    //         {
    //             Debug.DrawRay(transform.position, directions[i], Color.red);
    //             RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, directions[i], distance, playerMask);
    //             if (raycastHit2D.collider != null)
    //             {
    //                 fireAttack = true;
    //             }
    //         }
    //     }
    //     coolDownTimer += Time.deltaTime;

    // }

    // private void CheckDirection()
    // {
    //     directions[0] = transform.right * distance;
    //     directions[1] = -transform.right * distance;
    // }
    // private int FindFireBall()
    // {
    //     for (int i = 0; i < fireBalls.Length; i++)
    //     {
    //         if (!fireBalls[i].activeInHierarchy)
    //             return i;
    //     }
    //     return 0;
    // }
}
