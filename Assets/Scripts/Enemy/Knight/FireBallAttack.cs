using UnityEngine;

public class FireBallAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider2D;

    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float centerDistance;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private GameObject[] fireBalls;
    [SerializeField] private Transform firePoint;
    [SerializeField] private AudioClip attackSound;
    private Animator anim;
    private float coolDownTimer;

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
                anim.SetTrigger("fireBallAttack");
                SoundManager.instance.PlaySound(attackSound);
                coolDownTimer = 0;
            }
        }
        coolDownTimer += Time.deltaTime;
        if (GetComponent<Melee>() != null)
        {
            GetComponent<Melee>().enabled = !PlayerInsight();
        }

    }
    public bool PlayerInsight()
    {

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center + centerDistance * colliderDistance * transform.localScale.x * transform.right, new Vector3(boxCollider2D.bounds.size.x * colliderDistance, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z), 0, Vector2.left, 0, playerMask);
        // if (hit.collider != null)
        // {
        //     playerHealth = hit.collider.GetComponent<Health>();
        // }
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(boxCollider2D.bounds.center + centerDistance * colliderDistance * transform.localScale.x * transform.right, new Vector3(boxCollider2D.bounds.size.x * colliderDistance, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z));
    }

    private void Attack()
    {
        int i = FindFireBall();
        fireBalls[i].transform.position = firePoint.position;
        fireBalls[i].GetComponent<FireBall>().ActivateObject();

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