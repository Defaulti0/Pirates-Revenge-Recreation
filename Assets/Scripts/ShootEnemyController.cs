using UnityEngine;

public class ShootEnemyController : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public float fireRate = 1f;
    private float nextFireTime = 0f;
    public Transform firePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Shoot();
    }

    void Shoot() {
        if (Time.time >= nextFireTime) {
            Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + fireRate;
        }
    }
}
