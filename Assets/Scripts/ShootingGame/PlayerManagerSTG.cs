using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerSTG : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 5f;              //移動速度
    [SerializeField] private InputActionReference moveAction;   //移動入力アクション
    private Vector2 moveInput;

    [Header("攻撃設定")]
    [SerializeField] private float bulletSpeed = 10f;           //弾の速度
    [SerializeField] private int attackPower = 10;              //攻撃力
    [SerializeField] private float attackCooldown = 0.25f;      //攻撃間隔 
    [SerializeField] private Vector2 firePointOffset;
    [SerializeField] private BulletManagerSTG bulletPrefab;
    private float attackTimer;

    [Header("SE設定")]
    [SerializeField] private AudioClip shootSE;

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
        if (moveAction == null || bulletPrefab == null || !GameManagerSTG.Instance.isPlaying) return;

        //移動入力を取得して正規化
        moveInput = moveAction.action.ReadValue<Vector2>().normalized;

        //一定間隔で自動攻撃
        attackTimer += Time.deltaTime;
        //スコアに応じて攻撃間隔を短くする
        if (attackTimer >= attackCooldown * (1f - GameManagerSTG.Instance.score * 0.01f))
        {
            attackTimer = 0f;

            //SEを再生する
            SoundManager.Instance.PlaySE(shootSE);

            //弾を生成して発射
            var bullet = Instantiate(bulletPrefab, transform.position + (Vector3)firePointOffset, transform.rotation);
            bullet?.FireBullet(transform.up, bulletSpeed, attackPower);
        }
    }

    void FixedUpdate()
    {
        //プレイヤーを移動
        var move = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.fixedDeltaTime;
        transform.position += move;
    }
}
