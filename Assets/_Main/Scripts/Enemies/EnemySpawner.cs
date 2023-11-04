using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyTypeSO[] enemyTypeArray;

    private float spawnTimerMax;
    private float spawnTimer;
    private bool enemySpawned;

    private void Awake()
    {
        spawnTimerMax = Random.Range(0.5f, 1.5f);
        spawnTimer = spawnTimerMax;
    }

    private void Update()
    {
        if (enemySpawned) return;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            enemySpawned = true;
            SpawnEnemy();
            Destroy(gameObject);
        }
    }

    private void SpawnEnemy()
    {
        EnemyTypeSO enemyType = enemyTypeArray[Random.Range(0, enemyTypeArray.Length)];
        Instantiate(enemyType.EnemyPrefab, transform.position, Quaternion.identity, transform.parent);

        GameManager.EnemyTotalAmount++;
    }
}
