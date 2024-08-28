using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Vector3 m_distance;

    public float m_speed = 0.3f;

    private Vector3 m_startPosition;

    private Vector3 m_endPosition;

    private void Awake()
    {
        m_startPosition = transform.localPosition;

        m_endPosition = m_startPosition + m_distance;
    }

    private void Update()
    {
        var t = Mathf.PingPong(Time.time * m_speed, 1);
        var newPosition = Vector3.Lerp(m_startPosition, m_endPosition, t);

        transform.localPosition = newPosition;


    }
    // private void OnTriggerEnter2D(Collider2D collider2D)
    // {
    //     if (collider2D.CompareTag("Player"))
    //     {

    //     }
    // }
}