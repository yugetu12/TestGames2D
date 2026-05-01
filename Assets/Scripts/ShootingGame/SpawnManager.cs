using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private Vector3 spawnPos;
    private float timer;

    void Start()
    {
        //最初の敵を出現させる
        SpawnEnemy();
        timer = spawnInterval;
    }

    void Update()
    {
        if (!GameManager.Instance.isPlaying) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            //一定時間ごとに敵を出現させる
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    public void DecreaseInterval(float amount)
    {
        spawnInterval -= amount;
        //最小値と最大値を制限する
        spawnInterval = Mathf.Clamp(spawnInterval, 0.5f, 10f);
    }
}
