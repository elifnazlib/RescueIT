using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float speed;
    private Score _scoreScript;

    void Start()
    {
        _scoreScript = FindAnyObjectByType<Score>();
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Singleton.Instance.milkAmount -= 1.5f;
            _scoreScript.ChangeMilkAmountOnScreen(Singleton.Instance.milkAmount);
            
            Destroy(gameObject);
        }
    }    
}
