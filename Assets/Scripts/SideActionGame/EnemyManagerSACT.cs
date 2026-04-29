using UnityEngine;

public class EnemyManagerSACT : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveRange = 2f;

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

        //移動
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }
}
