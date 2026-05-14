using UnityEngine;
using UnityEngine.UI;

public class EnemyManagerCLK : MonoBehaviour
{
    public EnemyDataCLK enemyData;                  //敵のマスターデータ
    [SerializeField] private Text nameText;
    [SerializeField] private Text healthText;
    [SerializeField] private Image enemyImage;
    private int health;                             //敵の現在のHP

    void Start()
    {
        //敵の初期化 (1)
        if (enemyData != null)
        {
            InitEnemy(enemyData);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!GameManagerCLK.Instance.isPlaying) return;
        
        //ダメージを適用する
        health -= damage;

        //HPが0以下になったら死ぬ (4)
        if (health <= 0)
        {
            health = 0;
            Die();
        }

        if (healthText == null) return;
        //HPテキストを更新する
        healthText.text = health.ToString() + " / " + enemyData.maxHealth.ToString();
    }

    //敵の死亡処理 (3)
    private void Die()
    {
        //敵が死んだときの処理
        Debug.Log(enemyData.enemyName + "を倒した！");
        //次の敵をスポーンする
        GameManagerCLK.Instance.SpawnEnemy();
    }

    //敵の初期化 (2)
    public void InitEnemy(EnemyDataCLK data)
    {
        //敵のマスターデータを設定する
        enemyData = data;

        //HPを初期化する
        health = enemyData.maxHealth;

        //敵の名前を設定する
        nameText.text = enemyData.enemyName;
        //敵の画像を設定する
        enemyImage.sprite = enemyData.enemySprite;
        //HPテキストを更新する
        TakeDamage(0);
    }
}
