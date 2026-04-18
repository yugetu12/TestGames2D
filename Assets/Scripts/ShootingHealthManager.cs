using UnityEngine;

public class ShootingHealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;   //最大体力
    private int health;
    //外部参照用プロパティ
    public int CurrentHealth => health;
    public int MaxHealth => maxHealth;

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
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        //死亡処理
        Destroy(gameObject);
    }
}
