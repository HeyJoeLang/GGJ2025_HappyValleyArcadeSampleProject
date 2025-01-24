// EnemySpawner.cs
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = .5f;
    public float spawnXRangeMin = 1f;
    public float spawnXRangeMax = 16f;
    public float spawnY = 11f;
    bool spawnEnabled = true;

    private float spawnTimer;
    void Start()
    {
        PlayerHealthAndScore.OnGameOver += GameOver;
    }
    void Update()
    {
        if(!spawnEnabled)
        {
            return;
        }
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }
    public void GameOver()
    {
        spawnEnabled = false;
        EnemyBehaviour[] enemies = FindObjectsByType<EnemyBehaviour>(FindObjectsSortMode.InstanceID);
        foreach (EnemyBehaviour enemy in enemies) {
            Destroy(enemy.gameObject);
        }
    }
    void SpawnEnemy()
    {
        // Generate a random x-position within the defined range
        float randomX = Random.Range(spawnXRangeMin, spawnXRangeMax);

        // Instantiate the enemy at the calculated position
        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
