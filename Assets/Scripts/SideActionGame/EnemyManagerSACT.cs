using UnityEngine;

public class EnemyManagerSACT : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveRange = 2f;

    [Header("ジャンプ設定")]
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpInterval = 2f;
    private float jumpTimer = 0f;

    private Rigidbody2D rb;
    private int direction = 1;
    private Vector2 originPos;

    void Awake()
    {
        //コンポーネントを取得する
        rb = GetComponent<Rigidbody2D>();

        //初期座標を保存する
        originPos = transform.position;
    }

    void FixedUpdate()
    {
        //移動範囲を超えたら方向を反転する
        if (originPos.x - moveRange > transform.position.x)
        {
            direction = 1;
        }
        else if (originPos.x + moveRange < transform.position.x)
        {
            direction = -1;
        }

        //一定時間でジャンプする
        if (jumpTimer <= 0f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpTimer = jumpInterval;
        }
        else
        {
            jumpTimer -= Time.fixedDeltaTime;
        }

        //移動
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }
}
