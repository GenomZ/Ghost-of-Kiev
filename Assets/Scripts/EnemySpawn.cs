using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform EnemySpawnTransform;
    public float TimeBetweenSpawn = 2.0f;
    private float m_timeStamp = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO wait random amount before starting 1-5s?

        if (Time.time > m_timeStamp)
        {
            Spawn();
            m_timeStamp = Time.time + TimeBetweenSpawn;
            TimeBetweenSpawn = Random.Range(1.0f, 5.0f);
        }
    }

    private void Spawn()
    {
        var enemy = (GameObject)Instantiate(EnemyPrefab, EnemySpawnTransform.position, EnemySpawnTransform.rotation);

        //Add velocity to the bullet
        //bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;

        //Destroy bullet after 2s
        //Destroy(bullet, 2.0f);
    }
}
