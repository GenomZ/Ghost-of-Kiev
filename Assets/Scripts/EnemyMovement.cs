using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int enemySpeed;
    public Rigidbody2D rb;
    private Vector2 playerPosition;
    private Transform target;
    private Vector2 _direction;
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
            var v2 = new Vector2(target.position.x, target.position.y);
            _direction = v2 - rb.position;
            _direction.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), turnSpeed * Time.deltaTime);
        }

        playerPosition = new Vector2(target.position.x, target.position.y).normalized;

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
        //rb.velocity = new Vector2(playerPosition.x * enemySpeed * -1, playerPosition.y * enemySpeed * -1);
        Vector2 aimDirection = playerPosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
   
}
