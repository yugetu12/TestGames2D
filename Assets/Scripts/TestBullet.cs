using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TestBullet : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        //コンポーネントを取得する
        rb = GetComponent<Rigidbody2D>();
    }

    public void FireBullet(Vector2 direction, float speed)
    {
        //弾を発射する
        rb.linearVelocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //弾が何かに当たったら消える
        Destroy(gameObject);
    }
}
