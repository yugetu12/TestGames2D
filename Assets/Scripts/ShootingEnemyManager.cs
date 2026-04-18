using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootingEnemyManager : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float moveSpeed = 2f;         //移動速度
    [SerializeField] private bool startToRight = true;     //開始時の移動方向

    [Header("Attack")]
    [SerializeField] private float attackInterval = 1.5f;  //攻撃間隔
    [SerializeField] private int attackPower = 10;         //攻撃力
    [SerializeField] private float bulletSpeed = 8f;       //弾速
    [SerializeField] private Transform firePoint;          //弾を発射する位置
    [SerializeField] private ShootingTestBullet bulletPrefab; //発射する弾のプレハブ

    private Rigidbody2D rb;
    private float attackTimer;
    private float moveDirectionX;

    void Awake()
    {
        //コンポーネントを取得する
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //初期の移動方向を設定
        moveDirectionX = startToRight ? 1f : -1f;
    }

    void Update()
    {
        if (bulletPrefab == null || firePoint == null) return;

        //攻撃間隔を管理
        var safeAttackInterval = Mathf.Max(0.01f, attackInterval);
        attackTimer += Time.deltaTime;
        if (attackTimer < safeAttackInterval) return;

        attackTimer = 0f;

        //弾を下方向へ発射する
        var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.FireBullet(Vector2.down, bulletSpeed, attackPower);
    }

    void FixedUpdate()
    {
        //Rigidbody2DでX方向にのみ移動する
        rb.linearVelocity = new Vector2(moveDirectionX * moveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Wallタグに当たったら移動方向を反転
        if (collision.gameObject.CompareTag("Wall"))
        {
            ReverseDirection();
        }
    }

    private void ReverseDirection()
    {
        //移動方向を逆にする
        moveDirectionX *= -1f;
    }
}
