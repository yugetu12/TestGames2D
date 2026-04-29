using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerSACT : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    private Rigidbody2D rb;
    private Vector2 moveInput = Vector2.zero;
    private bool jumpQueued = false;

    void Awake()
    {
        //コンポーネントを取得する
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        //入力アクションを有効化
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    void OnDisable()
    {
        //入力アクションを無効化
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Update()
    {
        if (!GameManagerSACT.Instance.isPlaying) return;

        //入力を読む
        moveInput = moveAction.action.ReadValue<Vector2>();
        if (jumpAction.action.WasPressedThisFrame())
        {
            jumpQueued = true;
        }
    }

    void FixedUpdate()
    {
        //移動を適用
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        //ジャンプを適用
        if (jumpQueued && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpQueued = false;
        }
        else if (jumpQueued)
        {
            //空中にいるときはフラグを下ろす
            jumpQueued = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            //死んだときはゲームオーバーにする
            GameManagerSACT.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            //ゴールに触れたときはゲームクリアにする
            GameManagerSACT.Instance.GameClear();
        }
    }

    private bool IsGrounded()
    {
        //地面に接触しているかを確認する
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
