using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootingTestBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private int damage;

    private void Awake()
    {
        //コンポーネントを取得する
        rb = GetComponent<Rigidbody2D>();
    }

    public void FireBullet(Vector2 direction, float speed, int damage)
    {
        this.damage = Mathf.Max(0, damage);

        //弾を発射する
        rb.linearVelocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageable = other.GetComponent<ShootingHealthManager>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        //弾が何かに当たったら消える
        Destroy(gameObject);
    }
}
