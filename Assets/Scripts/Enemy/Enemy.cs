
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    private float leftEdge;
    private float rightEdge;
    private bool movingLeft;

    private void Awake()
    {
        rightEdge = transform.position.x + movementDistance;
        leftEdge = transform.position.x - movementDistance;

    }

    private void Update()
    {

        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

            }
            else
            {
                movingLeft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            collider2D.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
