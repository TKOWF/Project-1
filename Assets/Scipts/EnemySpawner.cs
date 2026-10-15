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
        foreach (Transform spawnPoint in spawnPoints)
        {
            enemyPool.GetEnemy(spawnPoint.position);
        }
    }
}