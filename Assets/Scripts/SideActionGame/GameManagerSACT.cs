using UnityEngine;

public class GameManagerSACT : MonoBehaviour
{
    public static GameManagerSACT Instance { get; private set; }
    public bool isPlaying;

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

    public void GameOver()
    {
        isPlaying = false;
        Debug.Log("ゲームオーバー！");
    }

    public void GameClear()
    {
        isPlaying = false;
        Debug.Log("ゲームクリア！");
    }
}
