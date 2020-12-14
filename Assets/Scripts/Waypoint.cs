using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;

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
                Debug.Log("Placing tower on: " + gameObject.name); 
            }
            if (!_isPlaceable)
            {
                Debug.Log("Block " + gameObject.name + " is part of the path!");
            }
            else 
            {
                return;
            }
        }
    }
}



