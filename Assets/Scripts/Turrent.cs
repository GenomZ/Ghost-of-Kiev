using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    private Transform target;
    public Transform turretTransform;

    public float aimAngle;
    public float range = 1;
    public float turnSpeed = 10f;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    private readonly string enemyTag = "Tank";
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        //for 3d
        //Vector3 dir = target.transform.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(turretTransform, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //turretTransform.rotation = Quaternion.Euler(0f, 0f, rotation.z);

        Vector3 aimDirection = target.transform.position - transform.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        turretTransform.rotation = Quaternion.Lerp(turretTransform.rotation, Quaternion.AngleAxis(aimAngle, Vector3.forward), Time.deltaTime * turnSpeed);
    
           if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        turretBullet bullet = bulletGO.GetComponent<turretBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distaneToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distaneToEnemy < shortestDistance)
            {
                shortestDistance = distaneToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
