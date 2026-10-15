using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private float damageCooldown = 1f;

    private int currentHealth;
    private float nextDamageTime;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (Time.time < nextDamageTime)
            return;

        currentHealth -= damage;
        nextDamageTime = Time.time + damageCooldown;

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
    Time.timeScale = 1f;

    SceneManager.LoadScene(
        SceneManager.GetActiveScene().buildIndex
    );
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}