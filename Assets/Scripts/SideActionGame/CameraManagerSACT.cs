using UnityEngine;

public class CameraManagerSACT : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Awake()
    {
        if (target == null) return;

        //カメラの初期位置をターゲットに合わせる
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        if (target == null) return;

        //カメラの位置をターゲットに合わせる
        transform.position = new Vector3(Mathf.Clamp(target.position.x, 0, float.MaxValue), transform.position.y, transform.position.z);
    }
}
