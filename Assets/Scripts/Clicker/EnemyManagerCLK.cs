using UnityEngine;

public class EnemyManagerCLK : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;

    void Start()
    {
        //HPを初期化する
        health = maxHealth;
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

        Debug.Log("敵のHP: " + health);
    }

    private void Die()
    {
        //敵が死んだときの処理
        Debug.Log("敵が倒れた！");
    }
}
