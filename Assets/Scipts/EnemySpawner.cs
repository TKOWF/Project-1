using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private Transform[] spawnPoints;

    void Start()
    {
        RespawnEnemies();
    }

    public void RespawnEnemies()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GameObject enemy = enemyPool.GetEnemy(
                spawnPoints[i].position
            );

            if (enemy != null)
            {
                EnemyHealth health =
                    enemy.GetComponent<EnemyHealth>();

                if (health != null)
                {
                    bool isLastEnemy =
                        i == spawnPoints.Length - 1;

                    health.SetFinalEnemy(isLastEnemy);
                }
            }
        }
    }
}