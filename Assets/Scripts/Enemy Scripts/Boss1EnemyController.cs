using UnityEngine;

public class Boss1EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private Transform firePoint;
    
    private float nextFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Time.time >= nextFireTime)
        {
            Instantiate(enemyData.projectilePrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + enemyData.fireRate;
        }
    }
}
