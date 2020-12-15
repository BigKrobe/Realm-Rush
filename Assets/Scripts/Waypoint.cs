using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    public bool _isExplored = false;
    public Waypoint exploredFrom;
    public bool _isPlaceable = true;


    Vector2Int _gridPos;

    const int _gridSize = 10;

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
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isPlaceable) 
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            if (!_isPlaceable)
            {
                { return; }
            }
            else 
            {
                return;
            }
        }
    }
}



