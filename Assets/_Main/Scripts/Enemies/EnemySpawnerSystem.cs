using UnityEngine;

public class EnemySpawnerSystem : MonoBehaviour
{
    [SerializeField] private Transform enemySpawnerPrefab;

    private float spawnTimerMax;
    private float spawnTimer;

    private int numberOfSpawner;
    private int numberOfSpawnerMax;

    private Vector3 spawnerPosition;

    private void Awake()
    {
        spawnTimerMax = Random.Range(0.5f, 2f);
        spawnTimer = spawnTimerMax;

        numberOfSpawnerMax = 5;
        numberOfSpawner = Random.Range(1, numberOfSpawnerMax);

        spawnerPosition = Vector3.zero;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0f)
        {
            spawnTimer = Random.Range(0.75f, 1.75f);
            SpawnAllSpawner();
        }
    }

    private void SpawnAllSpawner()
    {
        for (int i = 0; i < numberOfSpawner; i++)
        {
            spawnerPosition = new Vector3(Random.Range(-18f, 18f), Random.Range(-11f, 11f));

            Transform enemySpawnerTransform = Instantiate(enemySpawnerPrefab, spawnerPosition, Quaternion.identity);
            EnemySpawner enemySpawner = enemySpawnerTransform.GetComponent<EnemySpawner>();
        }

        numberOfSpawner = Random.Range(1, numberOfSpawnerMax);
    }
}
