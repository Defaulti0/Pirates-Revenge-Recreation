using UnityEngine;

public class ShootEnemyController : MonoBehaviour
{
    public EnemyData enemyData;
    private float nextFireTime = 0f;
    public Transform firePoint;

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
