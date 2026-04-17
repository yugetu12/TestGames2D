using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingPlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;              //移動速度
    [SerializeField] private float bulletSpeed = 10f;           //弾の速度
    [SerializeField] private InputActionReference moveAction;   //移動入力アクション
    [SerializeField] private InputActionReference attackAction; //攻撃入力アクション
    [SerializeField] private Transform firePoint;               //弾を発射する位置
    [SerializeField] private TestBullet bulletPrefab;           //発射する弾のプレハブ
    private Vector2 moveInput;

    void OnEnable()
    {
        //入力アクションを有効化
        moveAction?.action?.Enable();
        attackAction?.action?.Enable();
    }

    void OnDisable()
    {
        //入力アクションを無効化
        moveAction?.action?.Disable();
        attackAction?.action?.Disable();
    }

    void Update()
    {
        if (moveAction == null || attackAction == null) return;

        //移動入力を取得
        moveInput = moveAction.action.ReadValue<Vector2>().normalized;

        if (attackAction.action.WasPressedThisFrame())
        {
            //攻撃入力が押されたら弾を発射
            Shoot();
        }
    }

    void FixedUpdate()
    {
        //プレイヤーを移動
        var move = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.fixedDeltaTime;
        transform.position += move;
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        //弾を生成して発射
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.FireBullet(firePoint.up, bulletSpeed);
    }
}
