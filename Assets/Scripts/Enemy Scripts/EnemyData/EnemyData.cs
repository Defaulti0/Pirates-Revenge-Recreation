using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public int movementSpeed;
    public int score;
    public GameObject projectilePrefab;
    public int fireRate;

    [Header("Visual Customization")]
    public Color variationColor = Color.red;
}
