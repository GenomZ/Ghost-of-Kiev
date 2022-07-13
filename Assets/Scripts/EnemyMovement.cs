using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int enemySpeed;
    public Rigidbody2D rb;
    private Vector3 playerPosition;
    private Transform target;
    private Vector3 _direction;
    public float turnSpeed;

    void Awake()
    {

        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInput()
    {
        if (target)
        {
            _direction = playerPosition - rb.transform.position;
            _direction.Normalize();
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), turnSpeed * Time.deltaTime);
        }

        //var localPosition = _mPlayer.transform.position - transform.position;
        //localPosition = localPosition.normalized;
        //transform.Translate(localPosition.x * Time.deltaTime * enemySpeed,
        //                    localPosition.y * Time.deltaTime * enemySpeed,
        //                    0);

        //TODO rotation? wtf

        //playerPosition = new Vector2(_mPlayer.transform.position.x, _mPlayer.transform.position.y).normalized;
    }

    private void Move()
    {
        rb.AddForce(_direction * enemySpeed);

        Vector3 aimDirection = playerPosition - rb.transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);

    }

    protected void LookAt(Vector2 point)
    {

        float angle = AngleBetweenPoints(transform.position, point);
        var targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

    }
    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
