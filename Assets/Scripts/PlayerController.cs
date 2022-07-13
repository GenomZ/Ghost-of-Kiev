using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera sceneCamera;
    public float playerSpeed;
    public Rigidbody2D rb;

    public int weaponLevel = 0;

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

    private Vector2 movementRangeMin = new Vector2(-100f, -100f);
    private Vector2 movementRangeMax = new Vector2(100f, 100f);

    void Update()
    {
        //process inputs
        ProcessInputs();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerSpeed = 100; //lol thats a lot, looks like teleportation almost. Teleportation is a cool idea xD
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerSpeed = 10; //lol thats a lot, looks like teleportation almost. Teleportation is a cool idea xD
        }
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
            switch (weaponLevel)
            {
                default:
                    weapon_front_centre.Fire();
                    break;

                case 1:
                    weapon_front_centre.Fire();
                    weapon_front_left_1.Fire();
                    weapon_front_right_1.Fire();
                    break;

                case 2:
                    weapon_front_centre.Fire();
                    weapon_front_left_1.Fire();
                    weapon_front_left_2.Fire();
                    weapon_front_right_1.Fire();
                    weapon_front_right_2.Fire();
                    break;

                case 3:
                    weapon_front_centre.Fire();
                    weapon_front_left_1.Fire();
                    weapon_front_left_2.Fire();
                    weapon_front_right_1.Fire();
                    weapon_front_right_2.Fire();
                    weapon_back_centre.Fire();
                    break;

                case 4:
                    weapon_front_centre.Fire();
                    weapon_front_left_1.Fire();
                    weapon_front_left_2.Fire();
                    weapon_front_left_3.Fire();
                    weapon_front_right_1.Fire();
                    weapon_front_right_2.Fire();
                    weapon_front_right_3.Fire();

                    weapon_back_centre.Fire();
                    weapon_back_left_1.Fire();
                    weapon_back_right_1.Fire();
                    break;
                case 5:
                    weapon_front_centre.Fire();
                    weapon_front_left_1.Fire();
                    weapon_front_left_2.Fire();
                    weapon_front_left_3.Fire();
                    weapon_front_right_1.Fire();
                    weapon_front_right_2.Fire();
                    weapon_front_right_3.Fire();

                    weapon_front_left_1_angled.Fire();
                    weapon_front_right_1_angled.Fire();

                    weapon_back_centre.Fire();
                    weapon_back_left_1.Fire();
                    weapon_back_right_1.Fire();
                    break;
                case 6:
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
                    weapon_back_right_1.Fire();
                    break;

                case 7:
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
                    break;
            }
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), Mathf.Clamp(transform.position.y, -10, 10), transform.position.z);

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
