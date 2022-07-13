using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreate : MonoBehaviour
{
    public GameObject _tile;
    
    private GameObject _parent;
    private Grid grid;
    private int _size = 21;
    private float _length = 2.0f;
    private int _x;
    private int _y;
    void Awake()
    {
        //if (_size % 2 == 0)
        //{
        //  _size += 1;
        //}

        grid = new Grid(_size, 2.0f);
        _x = -((_size - 1) / 2) * (int)_length;
        _y = ((_size - 1)/ 2 ) * (int)_length;
        Debug.Log(_x + ", " + _y);

        _parent = new GameObject("MapGrid");

        for (int x = _x; x < grid.GetSize(); x++)
        {
            for (int y = _y; y < grid.GetSize(); y++)
            {
                SpawnObject(grid, x, y, _tile);
                Debug.Log(x + ", " + y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObject(Grid grid, int x, int z, GameObject obj)
    {
        // var tile = (GameObject)Instantiate(EnemyPrefab, EnemySpawnTransform.position, EnemySpawnTransform.rotation);
        var currentTile = Instantiate(obj, (_parent.transform), true);
        currentTile.transform.position = new Vector2(x * grid.GetCellSize(), z * grid.GetCellSize());
    }
}
