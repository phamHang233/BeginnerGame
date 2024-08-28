
using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool hit;
    private Animator anim;
    private float lifeTime;
    private float direction;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;

        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        hit = true;
        // boxCollider2D.enabled = false;
        anim.SetTrigger("explode");
        if (collider2D.CompareTag("Enemy"))
        {
            collider2D.GetComponent<Health>().TakeDamage(damage);
        }
        if (collider2D.CompareTag("Player"))
        {
            collider2D.GetComponent<Health>().TakeDamage(damage);

        }
    }

    public void SetDirection(float _direct)
    {
        lifeTime = 0;
        direction = _direct;
        hit = false;
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        gameObject.SetActive(true);

    }

    public void ActivateObject()
    {
        lifeTime = 0;
        hit = false;
        direction = 1;
        gameObject.SetActive(true);

    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
