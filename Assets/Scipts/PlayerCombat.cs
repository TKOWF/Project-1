using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 0.4f;

    private float nextAttackTime;
    private int facingDirection = 1;

    public void SetFacingDirection(int direction)
    {
        facingDirection = direction;
    }

    public void OnHit(InputValue value)
    {
        if (!value.isPressed || Time.time < nextAttackTime)
            return;

        nextAttackTime = Time.time + attackCooldown;

        Vector2 attackCenter = (Vector2)transform.position +
                               Vector2.right * facingDirection * attackRange * 0.5f;

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackCenter,
            attackRange * 0.5f
        );

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                EnemyHealth enemy = hit.GetComponent<EnemyHealth>();

                if (enemy != null)
                {
                    enemy.TakeDamage(attackDamage);
                }
            }
        }
    }
}