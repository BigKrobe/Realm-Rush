using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float _gridSize = 10f;

    TextMesh _textMesh;

    private void Start()
    {

    }

    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / 10f) * _gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * _gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        _textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPos.x / _gridSize + ", " + snapPos.z / _gridSize;
        _textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
