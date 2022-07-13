using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject impactEffect; //add particle effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gameManager = GameManager.Instance;
        switch (collision.gameObject.tag)
        {
            case "Plane":
                //reduce HP
                GameObject impactInstancePlane = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(impactInstancePlane, 2f);
                Destroy(gameObject);
                Destroy(collision.gameObject);
                //change Destroy collision.gameObject to:
                //collision.GameObject.GetComponent<EnemyDamageScript>TakeDamage();
                gameManager.i_russian_losses += 10;
                break;

            case "Tank":
                //reduce HP
                GameObject impactInstanceTank = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(impactInstanceTank, 2f);
                Destroy(gameObject);
                Destroy(collision.gameObject);
                //change Destroy collision.gameObject to:
                //collision.GameObject.GetComponent<EnemyDamageScript>TakeDamage();
                gameManager.i_russian_losses += 5;
                break;
        }
    }

    //private void Impact()
    //{
    //    Instantiate(imactEffect, transform.position, Quaternion.identity);
    //    Destroy(gameObject);
    //}
}
