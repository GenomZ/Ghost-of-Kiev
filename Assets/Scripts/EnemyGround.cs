using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGround : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    public Transform spriteTransform;
    private float aimAngle;
    public float turnSpeed = 10f;
    private int wavepointIndex = 0;
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        //var v2 = new Vector2(target.position.x, target.position.y);
        //_direction = v2 - rb.position;

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        Vector3 aimDirection = target.transform.position - spriteTransform.position;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        spriteTransform.rotation = Quaternion.Lerp(spriteTransform.rotation, Quaternion.AngleAxis(aimAngle, Vector3.forward), Time.deltaTime * turnSpeed);
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
