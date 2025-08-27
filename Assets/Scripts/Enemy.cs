using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Destroyer"))
        {
            Destroy(gameObject);
        }
    }

    
}
