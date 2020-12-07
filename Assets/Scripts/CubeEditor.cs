using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint _waypoint;

    private void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = _waypoint.GetGridSize();

        transform.position = new Vector3(_waypoint.GetGridPos().x, 0f, _waypoint.GetGridPos().y);
    }

    private void UpdateLabel()
    {
        int gridSize = _waypoint.GetGridSize();

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = 
            _waypoint.GetGridPos().x / gridSize + 
            ", " + 
            _waypoint.GetGridPos().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
