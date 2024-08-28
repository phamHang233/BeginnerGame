using Unity.VisualScripting;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            collider2D.GetComponent<Health>().AddHealth(1);
            gameObject.SetActive(false);

        }
    }
}
