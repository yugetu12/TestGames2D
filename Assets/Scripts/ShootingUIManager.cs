using UnityEngine;
using UnityEngine.UI;

public class ShootingUIManager : MonoBehaviour
{
    [SerializeField] private ShootingHealthManager playerHealth;    //プレイヤーの体力管理スクリプト
    [SerializeField] private Slider healthSlider;                   //体力表示用スライダー
    
    void Update()
    {
        if (playerHealth == null || healthSlider == null) return;
        
        //スライダーを更新
        healthSlider.value = playerHealth.CurrentHealth / (float)playerHealth.MaxHealth;
    }
}
