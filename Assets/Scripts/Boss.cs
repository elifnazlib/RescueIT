using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] new ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTransform.position.x, transform.position.y), 1 * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            particleSystem.transform.position = new Vector2(playerTransform.position.x + 1f, playerTransform.position.y + 2f);
            particleSystem.Play();
            playerTransform.position = new Vector2(other.transform.position.x - 2f, other.transform.position.y);
            transform.position = new Vector2(transform.position.x + 2f, transform.position.y);
            
        }
    }
}
