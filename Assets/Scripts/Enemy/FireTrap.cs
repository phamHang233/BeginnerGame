using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float timeDelay;
    [SerializeField] private float timeActivate;
    private bool isActive;
    private bool isTriggered;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            if (!isTriggered)
            {
                StartCoroutine(Activation());
            }
            if (isActive)
            {
                collider2D.GetComponent<Health>().TakeDamage(damage);
            }
        }
    }

    private IEnumerator Activation()
    {
        isTriggered = true;
        // canhr  báo lửa sắp cháy
        spriteRenderer.color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(timeDelay);
        spriteRenderer.color = new Color(1, 1, 1, 1);

        // bung chay nao!
        isActive = true;
        anim.SetBool("fire", true);
        yield return new WaitForSeconds(timeActivate);

        anim.SetBool("fire", false);
        isActive = false;
        isTriggered = false;




    }

}
