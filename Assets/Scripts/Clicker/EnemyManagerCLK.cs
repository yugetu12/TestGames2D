using UnityEngine;
using UnityEngine.UI;

public class EnemyManagerCLK : MonoBehaviour
{
    public string enemyName;                    //敵の名前
    public int maxHealth;                       //敵の最大HP
    public Sprite enemySprite;                  //敵の画像
    [SerializeField] private Text nameText;     //敵の名前を表示するテキストコンポーネント
    [SerializeField] private Text healthText;   //敵のHPを表示するテキストコンポーネント
    [SerializeField] private Image enemyImage;  //敵の画像を表示するイメージコンポーネント
    private int health;                         //敵のHP

    void Start()
    {
        //HPを初期化する (1)
        health = maxHealth;

        //敵の名前を設定する
        nameText.text = enemyName;
        //敵の画像を設定する
        enemyImage.sprite = enemySprite;
        //HPテキストを更新する (2)
        TakeDamage(0);
    }

    public void TakeDamage(int damage)
    {
        //ダメージを適用する (3)
        health -= damage;

        //HPが0以下になったら死ぬ (4)
        if (health <= 0)
        {
            health = 0;
            Debug.Log(enemyName + "を倒した！");
        }

        if (healthText == null) return;
        //HPテキストを更新する
        healthText.text = health.ToString() + " / " + maxHealth.ToString();
    }
}
