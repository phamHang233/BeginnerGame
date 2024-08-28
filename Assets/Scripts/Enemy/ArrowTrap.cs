using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float attakCoolDown;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private Transform FirePoint;

    private float coolDownTimer;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    private void Update()
    {


        if (coolDownTimer > attakCoolDown)
        {
            Attack();
        }
        coolDownTimer += Time.deltaTime;

    }

    private void Attack()
    {
        coolDownTimer = 0;
        int i = FindFireBall();
        arrows[i].transform.position = FirePoint.position;
        arrows[i].GetComponent<EnemyProjectile>().ActiveProjectile();
    }

    private int FindFireBall()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

}
