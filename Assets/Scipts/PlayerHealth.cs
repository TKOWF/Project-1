using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private float damageCooldown = 1f;

    private int currentHealth;
    private float nextDamageTime;
    private const string DeathsKey = "TotalDeaths";

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
        int totalDeaths = PlayerPrefs.GetInt(DeathsKey, 0);

        totalDeaths++;

        PlayerPrefs.SetInt(DeathsKey, totalDeaths);
        PlayerPrefs.Save();

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

    public bool Heal(int amount)
    {
        if (currentHealth >= maxHealth)
            return false;

        currentHealth = Mathf.Min(
            currentHealth + amount,
            maxHealth
        );

        return true;
    }
}