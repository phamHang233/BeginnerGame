using UnityEngine;

public class Trampoline : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D body;
    [SerializeField] float height;

    private void Awake()
    {
        // anim = GetComponent<Animator>();
        // body = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            body = other.GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(body.velocity.x, height);


        }
    }
}