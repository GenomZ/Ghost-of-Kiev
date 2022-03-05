using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;
    public float playerSpeed;
    public Rigidbody2D rb;

    public Weapon weapon_front_centre;
    public Weapon weapon_front_left_1;
    public Weapon weapon_front_left_2;
    public Weapon weapon_front_left_3;
    public Weapon weapon_front_right_1;
    public Weapon weapon_front_right_2;
    public Weapon weapon_front_right_3;

    public Weapon weapon_front_left_1_angled;
    public Weapon weapon_front_left_2_angled;
    public Weapon weapon_front_left_3_angled;
    public Weapon weapon_front_right_1_angled;
    public Weapon weapon_front_right_2_angled;
    public Weapon weapon_front_right_3_angled;

    public Weapon weapon_back_centre;
    public Weapon weapon_back_left_1;
    public Weapon weapon_back_left_2;
    public Weapon weapon_back_right_1;
    public Weapon weapon_back_right_2;


    private Vector2 moveDirection;
    private Vector2 mousePosotion;

    void Update()
    {
        //process inputs
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        //Physics calculations
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {

        weapon_front_centre.Fire();
        weapon_front_left_1.Fire();
        weapon_front_left_2.Fire();
        weapon_front_left_3.Fire();
        weapon_front_right_1.Fire();
        weapon_front_right_2.Fire();
        weapon_front_right_3.Fire();

        weapon_front_left_1_angled.Fire();
        weapon_front_left_2_angled.Fire();
        weapon_front_left_3_angled.Fire();
        weapon_front_right_1_angled.Fire();
        weapon_front_right_2_angled.Fire();
        weapon_front_right_3_angled.Fire();

        weapon_back_centre.Fire();
        weapon_back_left_1.Fire();
        weapon_back_left_2.Fire();
        weapon_back_right_1.Fire();
        weapon_back_right_2.Fire();
}
        //mousebutton 1 ROCKETS
        //space Booster
        //E Barrelroll!
        //ctrl pause and build tower defences?
        //mig-666 special plane endgame

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosotion = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed);
        //Rotate player ti follow mouse
        Vector2 aimDirection = mousePosotion - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Plane":
                //reduce HP
                Destroy(collision.gameObject);
                //change Destroy collision.gameObject to:
                //collision.GameObject.GetComponent<EnemyDamageScript>TakeDamage();
                break;
        }
    }
}
