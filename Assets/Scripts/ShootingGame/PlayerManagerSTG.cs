using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerSTG : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 5f;              //移動速度
    [SerializeField] private InputActionReference moveAction;   //移動入力アクション
    private Vector2 moveInput;

     void OnEnable()
    {
        //入力アクションを有効化
        moveAction?.action?.Enable();
    }

    void OnDisable()
    {
        //入力アクションを無効化
        moveAction?.action?.Disable();
    }

    void Update()
    {
        if (moveAction == null) return;

        //移動入力を取得して正規化
        moveInput = moveAction.action.ReadValue<Vector2>().normalized;
    }

    void FixedUpdate()
    {
        //プレイヤーを移動
        var move = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.fixedDeltaTime;
        transform.position += move;
    }
}
