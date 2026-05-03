using UnityEngine;

public class SlideBlockSACT : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;  //移動速度
    [SerializeField] private float range = 2f;      //移動範囲

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private bool movingRight = true;

    void Awake()
    {
        //コンポーネントを取得する
        rb = GetComponent<Rigidbody2D>();
        //初期位置を保存する
        startPosition = rb.position;
    }

    void FixedUpdate()
    {
        //移動範囲を超えたら反転する
        if (transform.position.x > startPosition.x + range)
        {
            movingRight = false;
        }
        else if (transform.position.x < startPosition.x)
        {
            movingRight = true;
        }

        //移動方向に応じて速度を適用する
        float direction = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }
}
