using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float stoppingDistance = 1f;

    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            animator.SetFloat("Speed", 0f);
            return;
        }

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        float horizontalDifference = player.position.x - transform.position.x;

        if (horizontalDifference != 0f)
        {
            spriteRenderer.flipX = horizontalDifference < 0f;
        }

        if (distance <= detectionRange && distance > stoppingDistance)
        {
            float direction = Mathf.Sign(horizontalDifference);

            rb.linearVelocity = new Vector2(
                direction * moveSpeed,
                rb.linearVelocity.y
            );

            animator.SetFloat("Speed", Mathf.Abs(direction * moveSpeed));
        }
        else
        {
            rb.linearVelocity = new Vector2(
                0f,
                rb.linearVelocity.y
            );

            animator.SetFloat("Speed", 0f);
        }
    }
}