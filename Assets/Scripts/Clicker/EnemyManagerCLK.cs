using UnityEngine;

public class EnemyManagerCLK : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //敵が死んだときの処理（例：アニメーション、スコア加算など）
    }
}
