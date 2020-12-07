using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //Vector2Int _gridPos;

    const int _gridSize = 10;

    public int GetGridSize()
    {
        return _gridSize;
    }

    public Vector2 GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize,
            Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize
        );
    }
}
