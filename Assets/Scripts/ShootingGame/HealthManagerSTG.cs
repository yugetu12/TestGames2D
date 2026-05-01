using UnityEngine;

public class HealthManagerSTG : MonoBehaviour
{
    public int maxHealth = 100;             //最大体力
    [HideInInspector] public int health;    //現在体力
    [SerializeField] private bool isEnemy = true;

    void Start()
    {
        //体力を初期化する
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        //ダメージを受ける
        health -= damage;

        if (health <= 0)
        {
            //スコアを加算する
            if (isEnemy)
            {
                GameManager.Instance.AddScore();
            }

            //死亡処理
            health = 0;
            if (!isEnemy)
            {
                GameManager.Instance.GameOver();
            }
            Destroy(gameObject);
        }
    }
}
