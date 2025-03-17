using UnityEngine;

public class Rouge : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootingRange = 10f;
    public float fireRate = 1f;

    private float nextFireTime = 1.0f;
    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= shootingRange)
        {
            // Shoot();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    // void Shoot()
    // {
    //     if (Time.time >= nextFireTime)
    //     {
    //         nextFireTime = Time.time + fireRate;
    //
    //         GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
    //         if (bullet != null)
    //         {
    //             bullet.transform.position = firePoint.position;
    //             bullet.transform.rotation = firePoint.rotation;
    //             bullet.SetActive(true);
    //
    //             Rigidbody rb = bullet.GetComponent<Rigidbody>();
    //             if (rb != null)
    //             {
    //                 rb.linearVelocity = firePoint.forward * 20f; // Bắn viên đạn
    //             }
    //             else
    //             {
    //                 Debug.LogWarning("Viên đạn không có Rigidbody!");
    //             }
    //         }
    //         else
    //         {
    //             Debug.LogWarning("Không có viên đạn nào trong Object Pool!");
    //         }
    //     }
    // }

    void OnBulletHit(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
