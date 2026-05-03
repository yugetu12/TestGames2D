using UnityEngine;

public class SwitchDoorSACT : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //ドアを開ける処理
            Destroy(gameObject);
            Debug.Log("ドアが開いた！");
        }
    }
}
