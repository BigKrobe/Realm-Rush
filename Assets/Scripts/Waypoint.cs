using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;

    // public ok here as is a data class
    public bool _isExplored = false;
    public Waypoint exploredFrom; 

    Vector2Int _gridPos;

    const int _gridSize = 10;

    void OnMouseOver()
    {
        Debug.Log("Mouse is over: " + gameObject.name);
    }

    public int GetGridSize()
    {
        return _gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / _gridSize),
            Mathf.RoundToInt(transform.position.z / _gridSize)
        );
    }

}



