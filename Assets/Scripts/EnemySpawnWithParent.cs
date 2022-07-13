using System.Collections;
using UnityEngine;

public class EnemySpawnWithParent : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject ParentPrefab;
    public Transform EnemySpawnTransform;
    public float TimeBetweenSpawn = 10.0f;
    private float countdown = 0f;
    private int waveNumber = 0;

    // Update is called once per frame
    void Update()
    {
        //TODO wait random amount before starting 1-5s?

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenSpawn;
            //TimeBetweenSpawn += Random.Range(1.0f, 5.0f);
            //Debug.Log(waveNumber);
        }
         
        countdown -= Time.deltaTime;
    }

    private IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            Spawn(EnemySpawnTransform, EnemyPrefab);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Spawn(Transform transf, GameObject obj)
    {
        //var enemy = (GameObject)Instantiate(EnemyPrefab, EnemySpawnTransform.position, EnemySpawnTransform.rotation);


        var currentTile = Instantiate(obj, (ParentPrefab.transform), true);
        currentTile.transform.position = new Vector2(transf.position.x, transf.position.y);

        //Add velocity to the bullet
        //bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 50;

        //Destroy bullet after 2s
        //Destroy(bullet, 2.0f);
    }
}
