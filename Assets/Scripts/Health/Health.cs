using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("IFrames")]
    [SerializeField] private float invulnerableDuration;
    [SerializeField] private float numberOfFlashs;
    [SerializeField] private AudioClip deadSound;
    [SerializeField] private AudioClip hurtSound;
    private SpriteRenderer spriteRenderer;

    [SerializeField] Behaviour[] components;
    private UIManager uIManager;


    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
        uIManager = FindObjectOfType<UIManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void TakeDamage(float dmg)
    {
        currentHealth = Mathf.Clamp(currentHealth - dmg, 0, startHealth);
        if (currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hurtSound);

            anim.SetTrigger("hurt");
            if (GetComponent<MovementController>() != null)
                StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                SoundManager.instance.PlaySound(deadSound);
                dead = true;
                if (GetComponent<Melee>() != null)
                {
                    GetComponent<Melee>().gameObject.SetActive(false);
                }
                foreach (Behaviour comp in components)
                {
                    comp.enabled = false;
                }

                if (GetComponent<MovementController>() != null)
                    uIManager.GameOver();


            }
        }
    }

    public void AddHealth(float _health)
    {
        currentHealth = Mathf.Clamp(currentHealth + _health, 0, startHealth);

    }
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOfFlashs; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0);
            yield return new WaitForSeconds(invulnerableDuration / 2 / numberOfFlashs);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(invulnerableDuration / 2 / numberOfFlashs);

        }
        Physics2D.IgnoreLayerCollision(8, 9, false);


    }
}
