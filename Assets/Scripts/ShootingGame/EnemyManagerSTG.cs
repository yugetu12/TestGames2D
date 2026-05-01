using UnityEngine;

public class EnemyManagerSTG : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 2f;         //移動速度
    [SerializeField] private bool startToRight = true;     //開始時の移動方向
    [SerializeField] private Rigidbody2D rb;
    private float moveDirectionX;

    [Header("攻撃設定")]
    [SerializeField] private float bulletSpeed = 8f;       //弾の速度
    [SerializeField] private int attackPower = 10;         //攻撃力
    [SerializeField] private float attackInterval = 1.25f; //攻撃間隔
    [SerializeField] private Vector2 firePointOffset;
    [SerializeField] private BulletManagerSTG bulletPrefab;
    private float attackTimer;

    void Start()
    {
        //初期の移動方向を設定
        if (startToRight)
        {
            moveDirectionX = 1f;
        }
        else
        {
            moveDirectionX = -1f;
        }
    }

    void Update()
    {
        if (bulletPrefab == null || !GameManager.Instance.isPlaying) return;

        //攻撃間隔を管理
        var safeAttackInterval = Mathf.Max(0.01f, attackInterval);
        attackTimer += Time.deltaTime;
        if (attackTimer < safeAttackInterval) return;

        attackTimer = 0f;

        //弾を下方向へ発射する
        var bullet = Instantiate(bulletPrefab, transform.position + (Vector3)firePointOffset, Quaternion.identity);
        bullet?.FireBullet(Vector2.down, bulletSpeed, attackPower);
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.isPlaying) return;
        
        //Rigidbody2DでX方向にのみ移動する
        rb.linearVelocity = new Vector2(moveDirectionX * moveSpeed, 0f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Wallタグに当たったら移動方向を反転
        if (collision.gameObject.CompareTag("Wall"))
        {
            moveDirectionX *= -1f;
        }
    }
}
