using UnityEngine;
using UnityEngine.UI;

public class EnemyManagerCLK : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;   //敵の最大HP
    private int health;                             //敵の現在のHP
    public EnemyDataCLK enemyData;                  //敵のマスターデータ
    [SerializeField] private Text enemyNameText;
    [SerializeField] private Text healthText;
    [SerializeField] private Image enemyImage;

    void Start()
    {
        //HPを初期化する
        health = maxHealth;
        //敵の名前を設定する
        enemyNameText.text = enemyData.enemyName;
        //HPテキストを更新する
        TakeDamage(0);
        //敵の画像を設定する
        enemyImage.sprite = enemyData.enemySprite;
    }

    public void TakeDamage(int damage)
    {
        //ダメージを適用する
        health -= damage;

        //HPが0以下になったら死ぬ
        if (health <= 0)
        {
            Die();
        }

        if (healthText == null) return;
        //HPテキストを更新する
        healthText.text = health.ToString() + " / " + maxHealth.ToString();
    }

    private void Die()
    {
        //敵が死んだときの処理
        Debug.Log("敵が倒れた！");
    }
}
