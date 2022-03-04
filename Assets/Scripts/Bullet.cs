using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    //public GameObject impactEffect; //add particle effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Plane":
            //reduce HP
                Destroy(gameObject);
                Destroy(collision.gameObject);
                //change Destroy collision.gameObject to:
                //collision.GameObject.GetComponent<EnemyDamageScript>TakeDamage();
                break;

            case "Tank":
            //reduce HP
                Destroy(gameObject);
                Destroy(collision.gameObject);
                //change Destroy collision.gameObject to:
                //collision.GameObject.GetComponent<EnemyDamageScript>TakeDamage();
                break;
        }
    }

    //private void Impact()
    //{
    //    Instantiate(imactEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}
}
