using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Grid
{

    private int gridSize;
    private float gridLenght;
    private Vector3 originPosition;
    private int[,] gridArray;

    public Grid(int gridSize, float gridLenght)
    {
        this.gridSize = gridSize;
        this.gridLenght = gridLenght;
        gridArray = new int[gridSize, gridSize];
    }
    public float GetSize()
    {
        return gridSize;
    }

    public float GetCellSize()
    {
        return gridLenght;
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * gridLenght + originPosition;
    }
}
