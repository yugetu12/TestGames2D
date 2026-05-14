using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataCLK", menuName = "Scriptable Objects/EnemyDataCLK")]
public class EnemyDataCLK : ScriptableObject
{
    public string enemyName;    //敵の名前
    public int maxHealth;       //敵の最大HP
    public Sprite enemySprite;  //敵の画像
}
