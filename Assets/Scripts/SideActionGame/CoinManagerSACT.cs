using UnityEngine;

public class CoinManagerSACT : MonoBehaviour
{
    [SerializeField] private int points = 1;    //コインのポイント
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //スコアを加算する
            GameManagerSACT.Instance.AddScore(points);
            Destroy(gameObject);
        }
    }
}
