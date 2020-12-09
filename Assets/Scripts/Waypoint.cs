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


    private void Update()
    {
        if (_isExplored == true)
        {
            SetTopColor(exploredColor);
        }       

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

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>(); // this finds the child objects in the object
        topMeshRenderer.material.color = color;
    }
}



