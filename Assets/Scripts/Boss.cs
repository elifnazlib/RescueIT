using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] new ParticleSystem particleSystem;
    [SerializeField] CountdownController _countdownController;
    [SerializeField] float leftValueX;
    [SerializeField] float rightValueX;
    [SerializeField] Movement _movementScript;
    [SerializeField] float speed;

    [SerializeField] Score _scoreScript;

    Rigidbody2D rb;
    [SerializeField] private float deathForce = 5f;
    [SerializeField] private float deathTorque = 300f;
    private int counter = 0;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bossDamageSFX;
    [SerializeField] AudioClip punchSFX;

    void Update()
    {
        if (_countdownController.isGameStarted)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerTransform.position.x, transform.position.y), speed * Time.deltaTime);

            Vector2 move = transform.position;
            move.x = Mathf.Clamp(move.x, leftValueX, rightValueX);
            transform.position = move;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(bossDamageSFX, 0.2f);

            particleSystem.transform.position = new Vector2(playerTransform.position.x + 1f, playerTransform.position.y + 2f);
            particleSystem.Play();

            playerTransform.position = new Vector2(other.transform.position.x - 2f, other.transform.position.y);
            transform.position = new Vector2(transform.position.x + 2f, transform.position.y);

            Singleton.Instance.milkAmount -= 2f;
            _scoreScript.ChangeMilkAmountOnScreen(Singleton.Instance.milkAmount);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Attack") && _movementScript.playerAttack == true)
        {
            audioSource.PlayOneShot(punchSFX);

            transform.position = new Vector2(transform.position.x + 2.5f, transform.position.y);
            _movementScript.playerAttack = false;

            counter++;
            if (counter == 10) BossDeath();
        }
    }

    void BossDeath()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();

        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        rb.AddForce(new Vector2(1, 1).normalized * deathForce, ForceMode2D.Impulse);
        rb.AddTorque(deathTorque);

        GetComponent<CircleCollider2D>().isTrigger = true;
        FindObjectOfType<Fader>().GetComponent<Fader>().GoToEndLevel();
        
        Destroy(gameObject, 5f);
    }
}
