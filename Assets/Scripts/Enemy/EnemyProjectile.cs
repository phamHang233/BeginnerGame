using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{

    [SerializeField] private float speed;
    [SerializeField] private float distance;
    private float direction;

    private float currentDistance;


    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);
        currentDistance += movementSpeed;
        if (currentDistance > distance)
        {
            gameObject.SetActive(false);
        }
    }
    public void ActiveProjectile()
    {

        gameObject.SetActive(true);
        currentDistance = 0;
    }


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        base.OnTriggerEnter2D(collider2D);
        gameObject.SetActive(false);

    }

}
