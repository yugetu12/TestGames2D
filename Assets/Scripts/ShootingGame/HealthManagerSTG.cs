using UnityEngine;

public class HealthManagerSTG : MonoBehaviour
{
    public int maxHealth = 100;             //最大体力
    [HideInInspector] public int health;    //現在体力

    void Start()
    {
        //体力を初期化
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        //ダメージを受ける
        health -= damage;

        if (health <= 0)
        {
            //死亡処理
            health = 0;
            Destroy(gameObject);
        }
    }
}
