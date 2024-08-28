using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [SerializeField] private float range;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private float timeDelay;

    private Vector3 destination;
    private Vector3[] directions = new Vector3[4];
    private float checkTimer;
    private bool attack;

    private void OnEnable()
    {
        Stop();
    }

    private void Update()
    {
        if (attack)
        {
            transform.Translate(speed * Time.deltaTime * destination);
        }
        else
        {
            checkTimer += Time.deltaTime;
            if (checkTimer > timeDelay)
            {
                FindPlayer();
                checkTimer = 0;
            }

        }
    }

    private void FindPlayer()
    {
        CheckDirection();
        for (int i = 0; i < 4; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerMask);
            if (hit.collider != null)
            {
                attack = true;
                destination = directions[i];

            }
        }

    }


    private void CheckDirection()
    {
        directions[0] = transform.right * range;
        directions[1] = -transform.right * range;
        directions[2] = transform.up * range;
        directions[3] = -transform.up * range;

    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        base.OnTriggerEnter2D(collider2D);
        Stop();

    }
    private void Stop()
    {
        destination = transform.position;
        attack = false;
    }

}
