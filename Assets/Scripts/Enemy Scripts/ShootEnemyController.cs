using UnityEngine;

public class ShootEnemyController : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public float fireRate = 1f;
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
            Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + fireRate;
        }
    }
}
