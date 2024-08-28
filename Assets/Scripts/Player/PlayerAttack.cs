using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;
    [SerializeField] private AudioClip attackSound;
    private float coolDownTimer = Mathf.Infinity; // thời gian từ phát bắn cuối cùng
    private Animator anim;
    private MovementController playerMovement;


    private void Awake()
    {
        attackCoolDown = 0.5f;
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<MovementController>();

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && coolDownTimer > attackCoolDown && playerMovement.CanAttack())
        {
            Attack();

        }
        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(attackSound);
        anim.SetTrigger("attack");
        coolDownTimer = 0;
        int i = FindFireBall();
        fireBalls[i].transform.position = firePoint.position;
        fireBalls[i].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));


    }

    private int FindFireBall()
    {
        for (int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
