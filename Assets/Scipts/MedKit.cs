using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerHealth playerHealth =
            other.GetComponent<PlayerHealth>();

        if (playerHealth != null &&
            playerHealth.Heal(healAmount))
        {
            gameObject.SetActive(false);
        }
    }
}