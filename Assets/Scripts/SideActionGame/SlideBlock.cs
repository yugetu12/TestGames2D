using UnityEngine;

public class SlideBlock : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float range = 2f;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private bool movingRight = true;

    void Awake()
    {
        //コンポーネントを取得する
        rb = GetComponent<Rigidbody2D>();
        //物理演算の影響を受けないようにする
        rb.isKinematic = true;
        //初期位置を保存する
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        //移動位置を計算する
        float destinationX = startPosition.x;
        if (movingRight)
        {
            destinationX = startPosition.x + range;
        }

        //現在の位置から目的地に向かって移動する
        float newPosX = Mathf.MoveTowards(transform.position.x, destinationX, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(new Vector2(newPosX, startPosition.y));

        if (movingRight && newPosX >= destinationX)
        {
            movingRight = false;
        }
        else if (!movingRight && newPosX <= destinationX)
        {
            movingRight = true;
        }
    }
}
