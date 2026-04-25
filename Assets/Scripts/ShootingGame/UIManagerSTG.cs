using UnityEngine;
using UnityEngine.UI;

public class UIManagerSTG : MonoBehaviour
{
    [SerializeField] private HealthManagerSTG playerHealth;
    [SerializeField] private Slider healthSlider;

    void Update()
    {
        if (playerHealth == null || healthSlider == null) return;

        //スライダーを更新
        healthSlider.value = playerHealth.health / (float)playerHealth.maxHealth;
    }
}
