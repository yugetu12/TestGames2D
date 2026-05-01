using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isPlaying = true;
    [SerializeField] private SpawnManager spawnMng;
    [SerializeField] private int scoreToClear = 50;
    [HideInInspector] public int score = 0;

    void Awake()
    {
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

    public void AddScore()
    {
        score++;
        //スコアが10の倍数になったら敵の出現間隔を短くする
        if (score % 10 == 0)
        {
            spawnMng.DecreaseInterval(0.5f);
        }

        if (score >= scoreToClear)
        {
            GameClear();
        }
    }

    public void GameOver()
    {
        isPlaying = false;
        Debug.Log("GameOver: Score = " + score);
    }

    public void GameClear()
    {
        isPlaying = false;
        Debug.Log("GameClear: Score = " + score);
    }
}
