using UnityEngine;

public class GameManagerCLK : MonoBehaviour
{
    public static GameManagerCLK Instance { get; private set; }
    [SerializeField] private EnemyManagerCLK enemyManager;      //EnemyManagerCLKの参照
    [SerializeField] private EnemyDataCLK[] enemyDataArray;     //敵のマスターデータの配列
    public bool isPlaying;
    private int currentIndex = 0;
    private int score = 0;
    private float timer = 0f;

    void Awake()
    {
        //シングルトンの初期化
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //ゲーム開始時の初期化
        score = 0;
        timer = 0f;
    }

    void Update()
    {
        if (isPlaying)
        {
            //経過時間を更新する (7)
            timer += Time.deltaTime;
        }
    }

    //敵の出現処理 (5)
    public void SpawnEnemy()
    {
        if (!isPlaying) return;

        //スコアを加算する
        AddScore(enemyDataArray[currentIndex].maxHealth);
        
        if (currentIndex < enemyDataArray.Length - 1)
        {
            //次の敵をスポーンする
            currentIndex++;
            enemyManager.InitEnemy(enemyDataArray[currentIndex]);
        }
        else
        {
            Debug.Log("すべての敵を倒した！");
            isPlaying = false;
        }
    }

    //スコア加算処理 (6)
    public void AddScore(int points)
    {
        //スコアを加算する
        score += points;

        //経過時間に応じてスコアを減少させる
        score -= Mathf.FloorToInt(timer);
        timer = 0f;
        Debug.Log("スコア: " + score);
    }
}
