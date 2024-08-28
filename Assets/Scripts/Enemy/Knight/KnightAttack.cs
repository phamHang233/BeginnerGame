using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;

    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float centerDistance;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private AudioClip attackSound;

    private float coolDownTimer;
    private float damage;
    private Animator anim;
    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (coolDownTimer > attackCoolDown)
        {
            if (PlayerInsight())
            {
                anim.SetBool("run", false);
                anim.SetTrigger("swordAttack");
                SoundManager.instance.PlaySound(attackSound);

                coolDownTimer = 0;
            }
        }
        coolDownTimer += Time.deltaTime;
    }
    public bool PlayerInsight()
    {

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center + centerDistance * colliderDistance * transform.localScale.x * transform.right, new Vector3(boxCollider2D.bounds.size.x * colliderDistance, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z), 0, Vector2.left, 0, playerMask);
        if (hit.collider != null)
        {
            playerHealth = hit.collider.GetComponent<Health>();
        }
        return hit.collider != null;
    }

    private void DamagePlayer()
    {
        if (PlayerInsight())
            playerHealth.TakeDamage(damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider2D.bounds.center + centerDistance * colliderDistance * transform.localScale.x * transform.right, new Vector3(boxCollider2D.bounds.size.x * colliderDistance, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z));
    }


}