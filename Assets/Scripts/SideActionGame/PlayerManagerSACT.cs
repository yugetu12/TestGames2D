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
        //コールバックを登録
        jumpAction.action.performed += OnJump;
    }

    void OnDisable()
    {
        //コールバックを解除
        jumpAction.action.performed -= OnJump;
        //入力アクションを無効化
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void FixedUpdate()
    {
        //移動入力を取得してプレイヤーを移動
        InputAction moveInput = moveAction.action;
        Vector2 move = moveInput.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(move.x * moveSpeed, rb.linearVelocity.y);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!IsGrounded()) return;

        //速度をリセットして上向きに力を加える
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        //地面に接触しているかを確認する
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
