using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] Vector2 spawnRange = new Vector2(15f, 8f); // 横幅, 高さ

    [SerializeField] float initialInterval = 3.0f; // スタート時のスポーン間隔（秒）
    [SerializeField] float minInterval = 1.0f;     // 最も早くなったときのスポーン間隔（秒）
    [SerializeField] float difficultySpeed = 0.05f; // 1秒ごとにどれくらい間隔を短くするか

    float spawnInterval;
    float timer;
    float elapsedTime;

    void Start()
    {
        spawnInterval = initialInterval;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        spawnInterval = Mathf.Max(minInterval, initialInterval - (elapsedTime * difficultySpeed));

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }
    void SpawnEnemy()
    {
        // 60秒経過したらスポーン終了
        if (elapsedTime >= 60f) return;

        float randomX = Random.Range(-spawnRange.x / 2f, spawnRange.x / 2f);
        float randomY = Random.Range(-spawnRange.y / 2f, spawnRange.y / 2f);

        Vector2 spawnPosition = (Vector2)transform.position + new Vector2(randomX, randomY);

        // お化けを選ぶ
        GameObject enemyToSpown;

        if (Random.value < 0.95f)
        {
            enemyToSpown = enemyPrefab;
        }
        else
        {
            enemyToSpown = enemyPrefab2;
        }

        // お化けの生成
        if (enemyToSpown != null)
        {
            Instantiate(enemyToSpown, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnRange);
    }
}
