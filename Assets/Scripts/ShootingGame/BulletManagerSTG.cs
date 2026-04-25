using UnityEngine;

public class BulletManagerSTG : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private int damage;

    public void FireBullet(Vector2 direction, float speed, int damage)
    {
        this.damage = Mathf.Max(0, damage);

        //弾を発射する
        rb.linearVelocity = direction.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var damageable = other.GetComponent<HealthManagerSTG>();
        damageable?.TakeDamage(damage);

        //弾が何かに当たったら消える
        Destroy(gameObject);
    }
}