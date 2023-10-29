using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyTypeSO[] enemyTypeArray;

    private float spawnTimerMax;
    private float spawnTimer;

    private void Awake()
    {
        spawnTimerMax = Random.Range(0.5f, 1.5f);
        spawnTimer = spawnTimerMax;
    }

    private void Update()
    {
        //TODO goes inside a SpawnManager
        //spawnTimer -= Time.deltaTime;
        //if (spawnTimer <= 0f)
        //{
        //    SpawnEnemy();
        //    Destroy(gameObject);
        //}
    }

    public void SpawnEnemy()
    {
        EnemyTypeSO enemyType = enemyTypeArray[Random.Range(0, enemyTypeArray.Length)];
        Transform enemyTransform = Instantiate(enemyType.EnemyPrefab, transform.position, Quaternion.identity);

        GameManager.EnemyTotalAmount++;
    }
}
